using UnityEngine;

public class DeckPickupBlocksGoldRule : MonoBehaviour, ICardPickupRule
{
    public void OnCardPickup(ResourceType _resourceType, int _currentTurnPickedUpAmount, bool _pickedUpFromDeck = false)
    {
        if (_pickedUpFromDeck && TurnManager.I.GetCurrentTurnContext().GetPickedUpCardCount() == 1)
        {
            TurnManager.I.GetCurrentTurnContext().SetPickedUpFromDeck(true);
            TurnManager.I.GetAllowedTurnActions().CanPickupGoldCardFromOutsideDeck = false;
        }
    }
}
