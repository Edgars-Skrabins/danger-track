using System;
using Mono.Cecil;
using TMPro;
using UnityEngine;

[Serializable]
public class ResourceUIObject
{
    public ResourceType resourceType;
    public TextMeshProUGUI textComponent;
}

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Player m_player;
    [SerializeField] private ResourceUIObject[] m_resourceUIObject;

    private void Start()
    {
        m_player.OnResourceUpdate += UpdateResourceUI;
    }

    private void UpdateResourceUI(ResourceType _resourceType)
    {
        ResourceUIObject resourceUIObject = Array.Find(
            m_resourceUIObject,
            resource => resource.resourceType == _resourceType
        );

        resourceUIObject.textComponent.text = m_player.GetResource(_resourceType).ToString();
    }

    private void OnDestroy()
    {
        m_player.OnResourceUpdate -= UpdateResourceUI;
    }
}
