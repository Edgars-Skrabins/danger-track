using System;
using UnityEngine;

[Serializable]
public class TrainDeckContent
{
    public TrainCardData cardData;
    public int amount;
}

[CreateAssetMenu(fileName = "TrainDeckCardPool", menuName = "Cards/Deck/TrainDeckCardPool")]
public class TrainDeckCardPool : ScriptableObject
{
    public TrainDeckContent[] contents;
}