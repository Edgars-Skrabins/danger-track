using System;
using Photon.Pun;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_playerPrefab;
    private void Start()
    {
        PhotonNetwork.Instantiate(m_playerPrefab.name, transform.position, transform.rotation);
    }
}
