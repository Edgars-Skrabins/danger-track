using Photon.Pun;
using TMPro;
using UnityEngine;

public class JoinRoomWidgetUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField m_roomNameInputField;

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(m_roomNameInputField.text);
    }
}
