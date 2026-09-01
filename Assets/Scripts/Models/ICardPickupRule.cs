public interface ICardPickupRule : ICardRule
{
    void OnCardPickup(ResourceType _resourceType, int _currentTurnPickedUpAmount, bool _pickedUpFromDeck = false);
}
