using UnityEngine;

[CreateAssetMenu(fileName = "ResourceBlocksGoldOutsideDeckRule", menuName = "Rules/ResourceBlocksGoldOutsideDeckRule")]
public class ResourceBlocksGoldOutsideDeckRule : CardPickupRuleBase
{
    public override void OnCardPickup(ResourceType _resourceType, int _currentTurnPickedUpAmount, bool _pickedUpFromDeck = false)
    {
        if (_currentTurnPickedUpAmount >= 1)
        {
            TurnManager.I.GetAllowedTurnActions().CanPickupGoldCardFromOutsideDeck = false;
        }
    }
}
