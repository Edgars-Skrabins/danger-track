using UnityEngine;

[CreateAssetMenu(fileName = "TrainCardEndsNextTurnRule", menuName = "Rules/TrainCardEndsNextTurnRule")]
public class TrainCardEndsRoundRule : TrainCardPickupRuleBase
{
    public override void OnTrainCardPickup(ResourceType _type)
    {
        TurnManager.I.EndTurn();
    }
}
