using UnityEngine;

public class CardPickupBonusRule : MonoBehaviour, ICardPickupRule
{
    [SerializeField] private int m_cardsNeededForBonus = 2;

    public void OnCardPickup(ResourceType _resourceType, int _currentTurnPickedUpAmount, bool _pickedUpFromDeck = false)
    {
        if (_currentTurnPickedUpAmount >= m_cardsNeededForBonus)
        {
            // TODO: Apply bonus
        }
    }
}
