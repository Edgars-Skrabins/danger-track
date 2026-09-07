using System;

[Serializable]
public struct TrainCardInfo
{
    public ResourceType Type;
    public int OriginalPrice;

    public TrainCardInfo(ResourceType _type, int _originalPrice)
    {
        Type = _type;
        OriginalPrice = _originalPrice;
    }
}
