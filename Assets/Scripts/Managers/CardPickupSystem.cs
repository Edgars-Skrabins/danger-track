using UnityEngine;

public class CardPickupSystem : NetworkedSingleton<CardPickupSystem>
{
    public void RaiseCardPickup(ResourceType _resourceType, bool _pickedUpFromDeck = false)
    {
        TurnContext currentContext = TurnManager.I.GetCurrentTurnContext();
        currentContext.AddPickedUpResourceCard();

        if (_pickedUpFromDeck)
        {
            currentContext.SetPickedUpFromDeck(true);
        }

        GameEvents.RaiseCardPickup(_resourceType, _pickedUpFromDeck);
    }
}
