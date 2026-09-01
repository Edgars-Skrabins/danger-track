[UnityEngine.CreateAssetMenu(fileName = "TrainCardEndsRoundRule", menuName = "Rules/TrainCardEndsRoundRule")]
public class TrainCardEndsRoundRule : TrainCardPickupRuleBase
{
    public override void OnTrainCardPickup(ResourceType _type)
    {
        TurnManager.I.EndTurn();
    }
}
