using System;
using UnityEngine;

[Serializable]
public class TrainDeckContent : IDeckContent<TrainCardData>
{
    public TrainCardData cardData;
    public int amount;

    public TrainCardData CardData => cardData;
    public int Amount => amount;
}

[CreateAssetMenu(fileName = "TrainDeckCardPool", menuName = "Cards/Deck/TrainDeckCardPool")]
public class TrainDeckCardPool : DeckCardPool<TrainCardData, TrainDeckContent>
{
    [SerializeField] private TrainDeckContent[] m_contents;
    public override TrainDeckContent[] Contents => m_contents;
}
