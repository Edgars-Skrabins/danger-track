using UnityEngine;

public class CardPickupSystem : NetworkedSingleton<CardPickupSystem>
{
    public void RaiseCardPickup(ResourceType _resourceType, bool _pickedUpFromDeck = false)
    {
        TurnContext currentContext = TurnManager.I.GetCurrentTurnContext();
        currentContext.AddPickedUpResourceCard();

        GameEvents.RaiseCardPickup(_resourceType, _pickedUpFromDeck);
    }
}
