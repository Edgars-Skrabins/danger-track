using UnityEngine;

[CreateAssetMenu(fileName = "ResourceBlocksTrainRule", menuName = "Rules/ResourceBlocksTrainRule")]
public class ResourceBlocksTrainRule : CardPickupRuleBase
{
    public override void OnCardPickup(ResourceType _resourceType, int _currentTurnPickedUpAmount, bool _pickedUpFromDeck = false)
    {
        TurnManager.I.GetCurrentTurnContext().SetResourcePickedUp(true);
    }
}
