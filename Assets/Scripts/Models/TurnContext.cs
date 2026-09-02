public class TurnContext
{
    private int m_pickedUpCardCount;
    private bool m_pickedUpFromDeck;

    public void AddPickedUpResourceCard() => m_pickedUpCardCount++;
    public int GetPickedUpCardCount() => m_pickedUpCardCount;
    public void ResetPickupCount() => m_pickedUpCardCount = 0;

    public void SetPickedUpFromDeck(bool _pickedUpFromDeck) => m_pickedUpFromDeck = _pickedUpFromDeck;
    public bool WasPickedUpFromDeck() => m_pickedUpFromDeck;
}
