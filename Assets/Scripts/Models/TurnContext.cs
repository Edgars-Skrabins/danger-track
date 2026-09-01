using System.Collections.Generic;

public class TurnContext
{
    private Dictionary<ResourceType, int> m_pickedUpResourceCounts = new();

    public TurnContext()
    {
        ResetPickupCounts();
    }

    public void AddPickedUpResourceCard(ResourceType _resourceType)
    {
        if (!m_pickedUpResourceCounts.ContainsKey(_resourceType))
        {
            m_pickedUpResourceCounts[_resourceType] = 0;
        }

        m_pickedUpResourceCounts[_resourceType]++;
    }

    public int GetPickedUpResourceCardAmount(ResourceType _resourceType)
    {
        return m_pickedUpResourceCounts.ContainsKey(_resourceType) ? m_pickedUpResourceCounts[_resourceType] : 0;
    }

    public int GetTotalPickedUpResourceCardAmount()
    {
        int total = 0;
        foreach (var count in m_pickedUpResourceCounts.Values)
        {
            total += count;
        }

        return total;
    }

    private void ResetPickupCounts()
    {
        m_pickedUpResourceCounts.Clear();
        foreach (ResourceType resourceType in System.Enum.GetValues(typeof(ResourceType)))
        {
            if (resourceType == ResourceType.Count) continue;
            m_pickedUpResourceCounts[resourceType] = 0;
        }
    }
}
