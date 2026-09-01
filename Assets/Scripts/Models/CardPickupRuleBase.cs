using UnityEngine;

public abstract class CardPickupRuleBase : ScriptableObject, ICardPickupRule
{
    public abstract void OnCardPickup(ResourceType _resourceType, int _currentTurnPickedUpAmount, bool _pickedUpFromDeck = false);
}
