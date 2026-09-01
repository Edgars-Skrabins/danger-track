using System;
using Photon.Pun;
using UnityEngine;

public class Player : MonoBehaviourPun
{
    public event Action<ResourceType> OnResourceUpdate;
    [SerializeField] private Camera m_camera;
    public Camera GetCamera() => m_camera;

    [SerializeField] private Canvas m_canvas;

    private void Start()
    {
        PlayerManager.I.RegisterPlayer(photonView);
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
        OnResourceUpdate?.Invoke(_resourceType);
    }

    public int GetResource(ResourceType resourceType)
    {
        return m_resources[(int)resourceType];
    }

    public void RemoveResource(ResourceType _resourceType, int amount)
    {
        m_resources[(int)_resourceType] -= amount;
        OnResourceUpdate?.Invoke(_resourceType);
    }

    private void OnDestroy()
    {
        PlayerManager.I.UnregisterPlayer(photonView);
    }
}
