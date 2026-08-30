using System;
using Photon.Pun;
using UnityEngine;

public class Player : MonoBehaviourPun
{
    public event Action OnResourceUpdate;
    [SerializeField] private Camera m_camera;
    [SerializeField] private Canvas m_canvas;

    private void Start()
    {
        if (!photonView.IsMine)
        {
            m_camera.gameObject.SetActive(false);
            m_canvas.gameObject.SetActive(false);
        }
    }

    private readonly int[] m_resources = new int[(int)ResourceType.Count];

    public void AddResource(ResourceType _resourceType, int _amount = 1)
    {
        m_resources[(int)_resourceType] += _amount;
        OnResourceUpdate?.Invoke();
    }

    public int GetResource(ResourceType resourceType)
    {
        return m_resources[(int)resourceType];
        OnResourceUpdate?.Invoke();
    }
}
