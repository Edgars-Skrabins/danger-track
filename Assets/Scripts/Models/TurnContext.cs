public class TurnContext
{
    private int m_pickedUpCardCount;

    public void AddPickedUpResourceCard() => m_pickedUpCardCount++;
    public int GetPickedUpCardCount() => m_pickedUpCardCount;
    public void ResetPickupCount() => m_pickedUpCardCount = 0;
}
