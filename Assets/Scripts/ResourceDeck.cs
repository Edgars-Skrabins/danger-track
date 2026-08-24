using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDeck : Deck
{
    private TrainDeckContent[] m_deckContents;
    private readonly List<ResourceCardData> m_cardsInDeck = new List<ResourceCardData>();


    public override void PopulateDeck()
    {
        throw new NotImplementedException();
    }

    protected override void PlaceCardInSlot(Transform _cardSlot)
    {
        throw new NotImplementedException();
    }
}