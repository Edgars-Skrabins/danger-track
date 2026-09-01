using System;

public static class GameEvents
{
    public static event Action<ResourceType, bool> OnCardPickup;
    public static event Action<CardType> OnTrainCardPickup;

    public static void RaiseCardPickup(ResourceType _resourceType, bool _pickedUpFromDeck = false)
    {
        OnCardPickup?.Invoke(_resourceType, _pickedUpFromDeck);
    }

    public static void RaiseTrainCardPickup(CardType _cardType)
    {
        OnTrainCardPickup?.Invoke(_cardType);
    }
}
