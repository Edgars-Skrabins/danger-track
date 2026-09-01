using UnityEngine;

public class RuleHandler : MonoBehaviour
{
    [SerializeField] private GameRulesSO m_gameRules;

    private void OnEnable()
    {
        GameEvents.OnCardPickup += HandleCardPickup;
        GameEvents.OnTrainCardPickup += HandleTrainCardPickup;
    }

    private void OnDisable()
    {
        GameEvents.OnCardPickup -= HandleCardPickup;
        GameEvents.OnTrainCardPickup -= HandleTrainCardPickup;
    }

    private void HandleCardPickup(ResourceType _resourceType, bool _pickedUpFromDeck)
    {
        TurnContext currentContext = TurnManager.I.GetCurrentTurnContext();
        int currentPickupAmount = currentContext.GetPickedUpCardCount();

        foreach (ICardPickupRule rule in m_gameRules.CardPickupRules)
        {
            rule.OnCardPickup(_resourceType, currentPickupAmount, _pickedUpFromDeck);
        }
    }

    private void HandleTrainCardPickup(ResourceType _type)
    {
        foreach (ICardTrainPickupRule rule in m_gameRules.TrainCardPickupRules)
        {
            rule.OnTrainCardPickup(_type);
        }
    }
}
