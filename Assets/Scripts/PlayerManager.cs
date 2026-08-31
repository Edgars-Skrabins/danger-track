using System;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private GameObject m_playerPrefab;

    private readonly List<PhotonView> m_spawnedPlayerPhotonViews = new List<PhotonView>();
    public List<PhotonView> GetSpawnedPlayerPhotonViews() => m_spawnedPlayerPhotonViews;

    protected override void Awake()
    {
        base.Awake();
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        GameObject spawnedPlayer = PhotonNetwork.Instantiate(m_playerPrefab.name, transform.position, transform.rotation);
        m_spawnedPlayerPhotonViews.Add(spawnedPlayer.GetComponent<PhotonView>());
    }

    public void RegisterPlayer(PhotonView photonView)
    {
        if (!m_spawnedPlayerPhotonViews.Contains(photonView))
        {
            m_spawnedPlayerPhotonViews.Add(photonView);
        }
    }

    public void UnregisterPlayer(PhotonView photonView)
    {
        m_spawnedPlayerPhotonViews.Remove(photonView);
    }
}
