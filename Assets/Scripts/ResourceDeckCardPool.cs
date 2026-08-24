using System;
using UnityEngine;

[Serializable]
public class ResourceDeckContent
{
    public ResourceCardData cardData;
    public int amount;
}

[CreateAssetMenu(fileName = "ResourceDeckCardPool", menuName = "Cards/Deck/ResourceDeckCardPool")]
public class ResourceDeckCardPool : ScriptableObject
{
    public ResourceDeckContent[] contents;
}