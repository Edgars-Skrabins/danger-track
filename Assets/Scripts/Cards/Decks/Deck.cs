using System;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using UnityEngine;

public abstract class Deck : MonoBehaviourPun
{
    public event Action OnAllCardsPlaced;

    [SerializeField] private Transform[] m_cardSlots;
    [SerializeField] private CardMaterialMapping[] m_cardMaterials;

    private void Start()
    {
        TurnManager.I.OnTurnOwnerChange += PlaceAllCards;
        PopulateDeck();
        PlaceAllCards();
    }

    public abstract void PopulateDeck();

    public void PlaceAllCards()
    {
        if (!PhotonNetwork.IsMasterClient) return;

        for (int i = 0; i < m_cardSlots.Length; i++)
        {
            if (IsSlotOccupied(i)) continue;
            PlaceCardInSlot(m_cardSlots[i], i);
        }

        OnAllCardsPlaced?.Invoke();
    }

    protected abstract void PlaceCardInSlot(Transform _cardSlot, int _slotIndex);
    protected abstract bool IsSlotOccupied(int _slotIndex);

    public Material GetCardMaterial(ResourceType _type)
    {
        return m_cardMaterials.First(x => x.type == _type).material;
    }
}

public abstract class Deck<TCard, TCardData, TDeckContent, TPool> : Deck
    where TCard        : Card
    where TCardData    : CardData
    where TDeckContent : IDeckContent<TCardData>
    where TPool        : DeckCardPool<TCardData, TDeckContent>
{
    [SerializeField] protected TCard m_cardPrefab;
    [SerializeField] protected TPool m_deckCardPool;

    protected readonly List<TCardData> m_cardsInDeck = new();
    protected readonly List<TCardData> m_placedCards  = new();

    public override void PopulateDeck()
    {
        if (!PhotonNetwork.IsMasterClient) return;

        m_cardsInDeck.Clear();
        m_placedCards.Clear();

        foreach (TDeckContent entry in m_deckCardPool.Contents)
        {
            for (int i = 0; i < entry.Amount; i++)
                m_cardsInDeck.Add(entry.CardData);
        }
    }

    protected override void PlaceCardInSlot(Transform _cardSlot, int _slotIndex)
    {
        if (m_cardsInDeck.Count == 0) return;

        int randomIndex    = UnityEngine.Random.Range(0, m_cardsInDeck.Count);
        TCardData cardData = m_cardsInDeck[randomIndex];
        m_cardsInDeck.RemoveAt(randomIndex);

        while (m_placedCards.Count <= _slotIndex)
            m_placedCards.Add(null);

        m_placedCards[_slotIndex] = cardData;

        GameObject cardObject = PhotonNetwork.Instantiate(
            m_cardPrefab.name,
            _cardSlot.position,
            _cardSlot.rotation);

        TCard card = cardObject.GetComponent<TCard>();
        card.OnCardRemoved += () => ClearSlot(_slotIndex, cardData);
        card.Initialize(this, cardData);
    }

    protected override bool IsSlotOccupied(int _slotIndex)
    {
        return _slotIndex >= 0 &&
               _slotIndex < m_placedCards.Count &&
               m_placedCards[_slotIndex] != null;
    }

    private void ClearSlot(int _slotIndex, TCardData _cardData)
    {
        if (_slotIndex < 0 || _slotIndex >= m_placedCards.Count) return;
        if (m_placedCards[_slotIndex] != _cardData) return;
        m_placedCards[_slotIndex] = null;
    }
}
