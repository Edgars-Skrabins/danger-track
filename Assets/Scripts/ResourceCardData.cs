using UnityEngine;

[CreateAssetMenu(fileName = "Resource_", menuName = "Cards/Resource")]
public class ResourceCardData : ScriptableObject
{
    public Sprite icon;
    public CardType type;
    public int value;
}