using Photon.Pun;
using TMPro;
using UnityEngine;

public class TurnOwnerTest : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_turnOwnerIdText;
    [SerializeField] private TextMeshProUGUI m_turnOwnerNameText;
    void Update()
    {
        int turnOwnerId = TurnManager.I.GetTurnOwnerViewId();
        m_turnOwnerIdText.text = "Current turn owner id: " + turnOwnerId;
        // m_turnOwnerNameText.text = "Turn owner name: " + PhotonView.Find(turnOwnerId)?.Owner?.NickName;
     }
}
