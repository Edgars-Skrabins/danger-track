public class Deck_Train : Deck<Card_Train, TrainCardData, TrainDeckContent, TrainDeckCardPool>
{
    public TrainCardData GetCardAtSlot(int _slotIndex)
    {
        if (_slotIndex < 0 || _slotIndex >= m_placedCards.Count) return null;
        return m_placedCards[_slotIndex];
    }

    public ResourceType GetFirstCardType()
    {
        for (int i = 0; i < m_placedCards.Count; i++)
        {
            if (m_placedCards[i] != null) return m_placedCards[i].type;
        }
        return default;
    }

    public ResourceType GetLastCardType()
    {
        for (int i = m_placedCards.Count - 1; i >= 0; i--)
        {
            if (m_placedCards[i] != null) return m_placedCards[i].type;
        }
        return default;
    }
}
