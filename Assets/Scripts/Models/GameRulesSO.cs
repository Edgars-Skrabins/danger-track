using UnityEngine;

[CreateAssetMenu(fileName = "GameRules", menuName = "Rules/Config/GameRules")]
public class GameRulesSO : ScriptableObject
{
    [SerializeField] private CardPickupRuleBase[] m_cardPickupRules;
    [SerializeField] private TrainCardPickupRuleBase[] m_trainCardPickupRules;

    public CardPickupRuleBase[] CardPickupRules => m_cardPickupRules;
    public TrainCardPickupRuleBase[] TrainCardPickupRules => m_trainCardPickupRules;
}
