using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NetworkLobbyManager : MonoBehaviourPunCallbacks
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            PhotonNetwork.LoadLevel("Game");
            Debug.Log("Load Level");
        }
    }

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("test", new RoomOptions(), TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created room");
    }
}