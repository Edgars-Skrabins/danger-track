using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomCodeWidget : MonoBehaviour
{
    private TextMeshProUGUI m_roomCodeText;
    private Button m_roomCodeButton;

    private void Start()
    {
        m_roomCodeText = GetComponent<TextMeshProUGUI>();
        m_roomCodeButton = GetComponent<Button>();
        SetRoomCodeText();
        EnableRoomCodeCopyOnPress();
    }

    private void SetRoomCodeText()
    {
        m_roomCodeText.text = PhotonNetwork.CurrentRoom.Name;
    }

    private void EnableRoomCodeCopyOnPress()
    {
        m_roomCodeButton.onClick.AddListener(() => GUIUtility.systemCopyBuffer = PhotonNetwork.CurrentRoom.Name);
    }
}