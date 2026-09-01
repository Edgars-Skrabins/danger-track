using UnityEngine;

public class TrainCardEndsRoundRule : MonoBehaviour, ICardTrainPickupRule
{
    public void OnTrainCardPickup(CardType _cardType)
    {
        TurnManager.I.EndTurn();
    }
}
