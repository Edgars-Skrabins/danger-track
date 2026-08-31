using UnityEngine;

public abstract class DeckCardPool<TCardData, TDeckContent> : ScriptableObject
    where TCardData    : CardData
    where TDeckContent : IDeckContent<TCardData>
{
    public abstract TDeckContent[] Contents { get; }
}
