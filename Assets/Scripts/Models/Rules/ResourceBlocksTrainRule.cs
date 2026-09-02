using UnityEngine;

public class ResourceBlocksTrainRule : MonoBehaviour, ICardPickupRule
{
    public void OnCardPickup(ResourceType _resourceType, int _currentTurnPickedUpAmount, bool _pickedUpFromDeck = false)
    {
        TurnManager.I.GetCurrentTurnContext().SetResourcePickedUp(true);
    }
}
