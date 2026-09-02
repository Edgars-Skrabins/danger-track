using UnityEngine;

[CreateAssetMenu(fileName = "TrainCardEndsTurnRule", menuName = "Rules/TrainCardEndsTurnRule")]
public class TrainCardEndsTurnRule : TrainCardPickupRuleBase
{
    public override void OnTrainCardPickup(ResourceType _type)
    {
        TurnManager.I.EndTurn();
    }
}
