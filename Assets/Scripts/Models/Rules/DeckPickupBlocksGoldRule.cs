using UnityEngine;

[CreateAssetMenu(fileName = "DeckPickupBlocksGoldRule", menuName = "Rules/DeckPickupBlocksGoldRule")]
public class DeckPickupBlocksGoldRule : CardPickupRuleBase
{
    public override void OnCardPickup(ResourceType _resourceType, int _currentTurnPickedUpAmount, bool _pickedUpFromDeck = false)
    {
        if (_pickedUpFromDeck && TurnManager.I.GetCurrentTurnContext().GetPickedUpCardCount() == 1)
        {
            TurnManager.I.GetCurrentTurnContext().SetPickedUpFromDeck(true);
            TurnManager.I.GetAllowedTurnActions().CanPickupGoldCardFromOutsideDeck = false;
        }
    }
}
