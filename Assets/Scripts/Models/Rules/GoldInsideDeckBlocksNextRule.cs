[UnityEngine.CreateAssetMenu(fileName = "GoldInsideDeckBlocksNextRule", menuName = "Rules/GoldInsideDeckBlocksNextRule")]
public class GoldInsideDeckBlocksNextRule : CardPickupRuleBase
{
    public override void OnCardPickup(ResourceType _resourceType, int _currentTurnPickedUpAmount, bool _pickedUpFromDeck = false)
    {
        if (_resourceType == ResourceType.Gold && _pickedUpFromDeck)
        {
            TurnManager.I.GetAllowedTurnActions().CanPickupResourceCards = false;
        }
    }
}
