using UnityEngine;

[CreateAssetMenu(fileName = "Train_", menuName = "Cards/Train")]
public class TrainCardData : ScriptableObject
{
    public CardType type;
    public int cost;
}