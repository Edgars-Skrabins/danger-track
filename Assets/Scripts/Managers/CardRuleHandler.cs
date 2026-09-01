using System.Collections.Generic;
using UnityEngine;

public class CardRuleHandler : MonoBehaviour
{
    [SerializeField] private List<MonoBehaviour> m_cardPickupRules = new();
    [SerializeField] private List<MonoBehaviour> m_trainCardPickupRules = new();

    private List<ICardPickupRule> m_pickupRulesCache = new();
    private List<ICardTrainPickupRule> m_trainPickupRulesCache = new();

    private void OnEnable()
    {
        GameEvents.OnCardPickup += HandleCardPickup;
        GameEvents.OnTrainCardPickup += HandleTrainCardPickup;
        CacheRules();
    }

    private void OnDisable()
    {
        GameEvents.OnCardPickup -= HandleCardPickup;
        GameEvents.OnTrainCardPickup -= HandleTrainCardPickup;
    }

    private void CacheRules()
    {
        m_pickupRulesCache.Clear();
        m_trainPickupRulesCache.Clear();

        foreach (MonoBehaviour ruleMono in m_cardPickupRules)
        {
            if (ruleMono is ICardPickupRule pickupRule)
            {
                m_pickupRulesCache.Add(pickupRule);
            }
        }

        foreach (MonoBehaviour ruleMono in m_trainCardPickupRules)
        {
            if (ruleMono is ICardTrainPickupRule trainRule)
            {
                m_trainPickupRulesCache.Add(trainRule);
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

    private void HandleTrainCardPickup(CardType _cardType)
    {
        foreach (ICardTrainPickupRule rule in m_trainPickupRulesCache)
        {
            rule.OnTrainCardPickup(_cardType);
        }
    }
}
