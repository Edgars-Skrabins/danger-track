using UnityEngine;

public abstract class TrainCardPickupRuleBase : ScriptableObject, ICardTrainPickupRule
{
    public abstract void OnTrainCardPickup(ResourceType _type);
}
