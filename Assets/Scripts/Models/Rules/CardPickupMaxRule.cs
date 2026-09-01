using UnityEngine;

public class CardPickupMaxRule : MonoBehaviour, ICardPickupRule
{
    [SerializeField] private int m_maxCardsPerTypePerTurn = 3;

    public void OnCardPickup(ResourceType _resourceType, int _currentTurnPickedUpAmount, bool _pickedUpFromDeck = false)
    {
        if (_currentTurnPickedUpAmount > m_maxCardsPerTypePerTurn)
        {
            // TODO: Implement prevention logic
        }
    }
}
