using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;


public class Deck_Resource : Deck
{
    [SerializeField] private Card_Resource m_resourceCard;
    [SerializeField] private ResourceDeckCardPool m_deckCardPool;
    private readonly List<ResourceCardData> m_cardsInDeck = new List<ResourceCardData>();

    public override void PopulateDeck()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }

        m_cardsInDeck.Clear();
        foreach (ResourceDeckContent deckContent in m_deckCardPool.contents)
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
        ResourceCardData randomCard = m_cardsInDeck[randomIndex];
        m_cardsInDeck.RemoveAt(randomIndex);

        GameObject cardObject = PhotonNetwork.Instantiate(
            m_resourceCard.name,
            _cardSlot.position,
            _cardSlot.rotation);

        Card_Resource card = cardObject.GetComponent<Card_Resource>();
        card.Initialize(this, randomCard);
    }
}