using System;

public static class GameEvents
{
    public static event Action<ResourceType, bool> OnCardPickup;

    public static void RaiseCardPickup(ResourceType _resourceType, bool _pickedUpFromDeck = false)
    {
        OnCardPickup?.Invoke(_resourceType, _pickedUpFromDeck);
    }
}
