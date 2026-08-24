using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

public class Deck_Train : Deck
{
    [SerializeField] private Card_Train _trainCard;
    [SerializeField] private TrainDeckCardPool m_deckCardPool;
    private readonly List<TrainCardData> m_cardsInDeck = new List<TrainCardData>();

    public override void PopulateDeck()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }

        m_cardsInDeck.Clear();
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
        TrainCardData randomCard = m_cardsInDeck[randomIndex];
        m_cardsInDeck.RemoveAt(randomIndex);

        GameObject cardObject = PhotonNetwork.Instantiate(
            _trainCard.name,
            _cardSlot.position,
            _cardSlot.rotation);

        Card_Train card = cardObject.GetComponent<Card_Train>();
        card.Initialize(this, randomCard);
    }
}