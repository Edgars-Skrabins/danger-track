using UnityEngine;

[CreateAssetMenu(fileName = "CardPickupBonusRule", menuName = "Rules/CardPickupBonusRule")]
public class CardPickupBonusRule : CardPickupRuleBase
{
    [SerializeField] private int m_cardsNeededForBonus = 2;

    public override void OnCardPickup(ResourceType _resourceType, int _currentTurnPickedUpAmount, bool _pickedUpFromDeck = false)
    {
        if (_currentTurnPickedUpAmount >= m_cardsNeededForBonus)
        {
            // TODO: Apply bonus
        }
    }
}
