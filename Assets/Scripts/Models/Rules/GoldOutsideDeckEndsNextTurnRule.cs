[UnityEngine.CreateAssetMenu(fileName = "GoldOutsideDeckEndsNextTurnRule", menuName = "Rules/GoldOutsideDeckEndsNextTurnRule")]
public class GoldOutsideDeckEndsNextTurnRule : CardPickupRuleBase
{
    public override void OnCardPickup(ResourceType _resourceType, int _currentTurnPickedUpAmount, bool _pickedUpFromDeck = false)
    {
        if (_resourceType == ResourceType.Gold && !_pickedUpFromDeck)
        {
            TurnManager.I.EndTurn();
        }
    }
}
