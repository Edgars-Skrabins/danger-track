using System.Collections.Generic;
using UnityEngine;

public class CardRuleHandler : MonoBehaviour
{
    [SerializeField] private List<MonoBehaviour> m_cardPickupRules = new();

    private List<ICardPickupRule> m_pickupRulesCache = new();

    private void OnEnable()
    {
        GameEvents.OnCardPickup += HandleCardPickup;
        CacheRules();
    }

    private void OnDisable()
    {
        GameEvents.OnCardPickup -= HandleCardPickup;
    }

    private void CacheRules()
    {
        m_pickupRulesCache.Clear();

        foreach (MonoBehaviour ruleMono in m_cardPickupRules)
        {
            if (ruleMono is ICardPickupRule pickupRule)
            {
                m_pickupRulesCache.Add(pickupRule);
            }
        }
    }

    private void HandleCardPickup(ResourceType _resourceType, bool _pickedUpFromDeck)
    {
        TurnContext currentContext = TurnManager.I.GetCurrentTurnContext();
        int currentPickupAmount = currentContext.GetPickedUpResourceCardAmount(_resourceType);

        foreach (ICardPickupRule rule in m_pickupRulesCache)
        {
            rule.OnCardPickup(_resourceType, currentPickupAmount, _pickedUpFromDeck);
        }
    }
}
