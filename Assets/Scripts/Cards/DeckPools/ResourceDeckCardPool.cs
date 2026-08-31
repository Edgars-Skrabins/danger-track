using System;
using UnityEngine;

[Serializable]
public class ResourceDeckContent : IDeckContent<ResourceCardData>
{
    public ResourceCardData cardData;
    public int amount;

    public ResourceCardData CardData => cardData;
    public int Amount => amount;
}

[CreateAssetMenu(fileName = "ResourceDeckCardPool", menuName = "Cards/Deck/ResourceDeckCardPool")]
public class ResourceDeckCardPool : DeckCardPool<ResourceCardData, ResourceDeckContent>
{
    [SerializeField] private ResourceDeckContent[] m_contents;
    public override ResourceDeckContent[] Contents => m_contents;
}
