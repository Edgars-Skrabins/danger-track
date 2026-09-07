using System;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Player : MonoBehaviourPun
{
    public event Action<ResourceType> OnResourceUpdate;
    public event Action<TrainCardInfo> OnTrainCardBought;

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
    private readonly List<TrainCardInfo> m_trainCards = new();

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

    public void AddTrainCard(ResourceType _trainType, int _originalPrice)
    {
        photonView.RPC(nameof(AddTrainCardRPC), RpcTarget.AllBuffered, _trainType, _originalPrice);
    }

    [PunRPC]
    private void AddTrainCardRPC(ResourceType _trainType, int _originalPrice)
    {
        TrainCardInfo cardInfo = new TrainCardInfo(_trainType, _originalPrice);
        m_trainCards.Add(cardInfo);
        OnTrainCardBought?.Invoke(cardInfo);
    }

    public List<TrainCardInfo> GetTrainCards() => m_trainCards;

    private void OnDestroy()
    {
        PlayerManager.I.UnregisterPlayer(photonView);
    }
}
