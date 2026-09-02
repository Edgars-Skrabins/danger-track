using UnityEngine;

[CreateAssetMenu(fileName = "GoldOutsideDeckEndsTurnRule", menuName = "Rules/GoldOutsideDeckEndsTurnRule")]
public class GoldOutsideDeckEndsTurnRule : CardPickupRuleBase
{
    public override void OnCardPickup(ResourceType _resourceType, int _currentTurnPickedUpAmount, bool _pickedUpFromDeck = false)
    {
        if (_resourceType == ResourceType.Gold && !_pickedUpFromDeck)
        {
            TurnManager.I.EndTurn();
        }
    }
}
