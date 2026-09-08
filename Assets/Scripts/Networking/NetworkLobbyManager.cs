using Photon.Pun;
using UnityEngine;

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

    // public override void OnJoinedLobby()
    // {
    //     PhotonNetwork.JoinOrCreateRoom("test", new RoomOptions(), TypedLobby.Default);
    // }
}
