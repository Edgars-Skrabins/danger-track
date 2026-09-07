using JetBrains.Annotations;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class Seat : MonoBehaviourPun
{
    [SerializeField] private TextMeshProUGUI m_nicknameText;
    [CanBeNull] private PhotonView m_seatedPlayer;

    public void AssignPlayer(int _photonViewId)
    {
        PhotonView view = PhotonView.Find(_photonViewId);
        m_seatedPlayer = view;
        m_nicknameText.text = view.ViewID.ToString();
    }

    public bool HasAssignedPlayer()
    {
        return m_seatedPlayer != null;
    }
}