using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class CreateRoomWidgetUI : MonoBehaviourPunCallbacks
{
    public void CreateRoom()
    {
        string roomCode = RoomCodeGenerator.GenerateCode();

        RoomOptions options = new()
        {
            MaxPlayers = 4,
        };

        PhotonNetwork.CreateRoom(roomCode, options);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        if (returnCode == ErrorCode.GameIdAlreadyExists)
        {
            CreateRoom();
        }
    }

    public override void OnCreatedRoom()
    {
        SceneManager.LoadScene((int)Scenes.Lobby);
    }
}
