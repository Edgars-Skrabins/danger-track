using UnityEngine;

[CreateAssetMenu(fileName = "TwoResourceCardsEndsTurnRule", menuName = "Rules/TwoResourceCardsEndsTurnRule")]
public class TwoResourceCardsEndsTurnRule : CardPickupRuleBase
{
    public override void OnCardPickup(ResourceType _resourceType, int _currentTurnPickedUpAmount, bool _pickedUpFromDeck = false)
    {
        if (_currentTurnPickedUpAmount >= 2)
        {
            TurnManager.I.EndTurn();
        }
    }
}
