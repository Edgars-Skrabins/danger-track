using UnityEngine;

public class TrainCardEndsRoundRule : MonoBehaviour, ICardTrainPickupRule
{
    public void OnTrainCardPickup(ResourceType _type)
    {
        TurnManager.I.EndTurn();
    }
}
