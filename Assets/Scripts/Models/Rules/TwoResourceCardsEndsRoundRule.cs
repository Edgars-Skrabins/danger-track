using UnityEngine;

public class TwoResourceCardsEndsRoundRule : MonoBehaviour, ICardPickupRule
{
    public void OnCardPickup(ResourceType _resourceType, int _currentTurnPickedUpAmount, bool _pickedUpFromDeck = false)
    {
        if (_currentTurnPickedUpAmount >= 2)
        {
            TurnManager.I.EndTurn();
        }
    }
}
