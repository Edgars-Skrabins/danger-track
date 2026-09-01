[UnityEngine.CreateAssetMenu(fileName = "TwoResourceCardsEndsRoundRule", menuName = "Rules/TwoResourceCardsEndsRoundRule")]
public class TwoResourceCardsEndsRoundRule : CardPickupRuleBase
{
    public override void OnCardPickup(ResourceType _resourceType, int _currentTurnPickedUpAmount, bool _pickedUpFromDeck = false)
    {
        if (_currentTurnPickedUpAmount >= 2)
        {
            TurnManager.I.EndTurn();
        }
    }
}
