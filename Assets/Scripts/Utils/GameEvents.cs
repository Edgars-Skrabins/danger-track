using System;

public static class GameEvents
{
    public static event Action<ResourceType, bool> OnCardPickup;
    public static event Action<ResourceType> OnTrainCardPickup;

    public static void RaiseCardPickup(ResourceType _resourceType, bool _pickedUpFromDeck = false)
    {
        OnCardPickup?.Invoke(_resourceType, _pickedUpFromDeck);
    }

    public static void RaiseTrainCardPickup(ResourceType _type)
    {
        OnTrainCardPickup?.Invoke(_type);
    }
}
