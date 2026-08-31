using System;
using System.Collections.Generic;
using Photon.Pun;

public class TurnManager : NetworkedSingleton<TurnManager>
{
    public event Action OnTurnOwnerChange;
    private int m_turnOwnerViewId;
    public int GetTurnOwnerViewId() => m_turnOwnerViewId;
    private int m_turnIndex;

    private void Start()
    {
        StartNextTurn();
    }

    public void StartNextTurn()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }

        List<PhotonView> playerList = PlayerManager.I.GetSpawnedPlayerPhotonViews();
        if (playerList[m_turnIndex] == null)
        {
            m_turnIndex = 0;
        }

        SetTurnOwner(playerList[m_turnIndex]);
        m_turnIndex++;
    }

    private void SetTurnOwner(PhotonView _photonView)
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }

        photonView.RPC(
            nameof(SetTurnOwnerRPC),
            RpcTarget.All,
            _photonView.ViewID
        );
    }

    [PunRPC]
    private void SetTurnOwnerRPC(int _viewId)
    {
        m_turnOwnerViewId = _viewId;
        OnTurnOwnerChange?.Invoke();
    }

    public bool IsMyTurn(int _viewId)
    {
        return _viewId == m_turnOwnerViewId;
    }
}
