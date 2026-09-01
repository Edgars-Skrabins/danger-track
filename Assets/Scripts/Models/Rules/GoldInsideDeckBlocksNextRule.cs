using UnityEngine;

public class GoldInsideDeckBlocksNextRule : MonoBehaviour, ICardPickupRule
{
    public void OnCardPickup(ResourceType _resourceType, int _currentTurnPickedUpAmount, bool _pickedUpFromDeck = false)
    {
        if (_resourceType == ResourceType.Gold && _pickedUpFromDeck)
        {
            TurnManager.I.GetAllowedTurnActions().CanPickupResourceCards = false;
        }
    }
}
