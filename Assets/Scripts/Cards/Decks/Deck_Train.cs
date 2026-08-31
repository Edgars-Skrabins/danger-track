using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

public class Deck_Train : Deck
{
    [SerializeField] private Card_Train m_trainCard;
    [SerializeField] private TrainDeckCardPool m_deckCardPool;

    private readonly List<TrainCardData> m_cardsInDeck = new();
    private readonly List<TrainCardData> m_placedCards = new();

    public override void PopulateDeck()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }

        m_cardsInDeck.Clear();
        m_placedCards.Clear();

        foreach (TrainDeckContent deckContent in m_deckCardPool.contents)
        {
            for (int i = 0; i < deckContent.amount; i++)
            {
                m_cardsInDeck.Add(deckContent.cardData);
            }
        }
    }

    protected override void PlaceCardInSlot(Transform _cardSlot, int _slotIndex)
    {
        if (m_cardsInDeck.Count == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, m_cardsInDeck.Count);
        TrainCardData cardData = m_cardsInDeck[randomIndex];

        m_cardsInDeck.RemoveAt(randomIndex);

        while (m_placedCards.Count <= _slotIndex)
        {
            m_placedCards.Add(null);
        }

        m_placedCards[_slotIndex] = cardData;

        GameObject cardObject = PhotonNetwork.Instantiate(
            m_trainCard.name,
            _cardSlot.position,
            _cardSlot.rotation);

        Card_Train card = cardObject.GetComponent<Card_Train>();

        card.OnCardRemoved += () => RemoveCardFromSlot(_slotIndex, cardData);

        card.Initialize(this, cardData);
    }

    protected override bool IsSlotOccupied(int _slotIndex)
    {
        return _slotIndex >= 0 &&
               _slotIndex < m_placedCards.Count &&
               m_placedCards[_slotIndex] != null;
    }

    private void RemoveCardFromSlot(int _slotIndex, TrainCardData _cardData)
    {
        if (_slotIndex < 0 || _slotIndex >= m_placedCards.Count)
        {
            return;
        }

        if (m_placedCards[_slotIndex] != _cardData)
        {
            return;
        }

        m_placedCards[_slotIndex] = null;
    }

    public ResourceType GetLastCardType()
    {
        for (int i = m_placedCards.Count - 1; i >= 0; i--)
        {
            if (m_placedCards[i] != null)
            {
                return m_placedCards[i].type;
            }
        }

        return default;
    }

    public ResourceType GetFirstCardType()
    {
        for (int i = 0; i < m_placedCards.Count; i++)
        {
            if (m_placedCards[i] != null)
            {
                return m_placedCards[i].type;
            }
        }

        return default;
    }

    public TrainCardData GetCardAtSlot(int _slotIndex)
    {
        if (_slotIndex < 0 || _slotIndex >= m_placedCards.Count)
        {
            return null;
        }

        return m_placedCards[_slotIndex];
    }
}
