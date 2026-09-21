using Photon.Pun;
using UnityEngine;

public class StartGameWidget : MonoBehaviour
{
    public void AttemptStartGame()
    {
        StartGame();
    }

    private void StartGame()
    {
        PhotonNetwork.LoadLevel((int)Scenes.Game);
    }
}