using UnityEngine;

[CreateAssetMenu(fileName = "CardPickupMaxRule", menuName = "Rules/CardPickupMaxRule")]
public class CardPickupMaxRule : CardPickupRuleBase
{
    [SerializeField] private int m_maxCardsPerTypePerTurn = 3;

    public override void OnCardPickup(ResourceType _resourceType, int _currentTurnPickedUpAmount, bool _pickedUpFromDeck = false)
    {
        Debug.Log("pickedUpAmount: " + _currentTurnPickedUpAmount + "maxCardsPerTypePerTurn: " + m_maxCardsPerTypePerTurn);
        if (_currentTurnPickedUpAmount > m_maxCardsPerTypePerTurn)
        {
            TurnManager.I.EndTurn();
        }
    }
}
