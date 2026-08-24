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

    protected override void PlaceCardInSlot(Transform _cardSlot)
    {
        if (m_cardsInDeck.Count == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, m_cardsInDeck.Count);
        TrainCardData cardData = m_cardsInDeck[randomIndex];

        m_cardsInDeck.RemoveAt(randomIndex);
        m_placedCards.Insert(0, cardData);

        GameObject cardObject = PhotonNetwork.Instantiate(
            m_trainCard.name,
            _cardSlot.position,
            _cardSlot.rotation);

        Card_Train card = cardObject.GetComponent<Card_Train>();
        card.Initialize(this, cardData);
    }

    public CardType GetLastCardType()
    {
        return m_placedCards.Count == 0 ? default : m_placedCards[0].type;
    }

    public CardType GetFirstCardType()
    {
        return m_placedCards.Count == 0 ? default : m_placedCards[^1].type;
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