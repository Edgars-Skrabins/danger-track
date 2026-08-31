using System;
using System.Collections.Generic;
using Photon.Pun;

public partial class TurnManager : NetworkedSingleton<TurnManager>
{
    public event Action OnTurnOwnerChange;

    private int m_turnOwnerViewId;
    private int m_turnIndex;

    public int GetTurnOwnerViewId() => m_turnOwnerViewId;

    private void Start()
    {
        StartNextTurn();
    }

    public void StartNextTurn()
    {
        if (!PhotonNetwork.IsMasterClient) return;

        List<PhotonView> playerList = PlayerManager.I.GetSpawnedPlayerPhotonViews();

        if (playerList.Count <= m_turnIndex)
            m_turnIndex = 0;

        SetTurnOwner(playerList[m_turnIndex]);
        m_turnIndex++;
    }

    private void SetTurnOwner(PhotonView _photonView)
    {
        if (!PhotonNetwork.IsMasterClient) return;

        photonView.RPC(
            nameof(SetTurnOwnerRPC),
            RpcTarget.All,
            _photonView.ViewID);
    }

    public bool IsMyTurn(int _viewId) => _viewId == m_turnOwnerViewId;
}
