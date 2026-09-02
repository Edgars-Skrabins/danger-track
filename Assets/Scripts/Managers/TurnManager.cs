using System;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public partial class TurnManager : NetworkedSingleton<TurnManager>
{
    public event Action OnTurnOwnerChange;

    private int m_turnOwnerViewId;
    private int m_turnIndex;
    private TurnContext m_currentTurnContext;
    private AllowedTurnActions m_allowedTurnActions;
    private List<TurnContext> m_turnHistory = new();

    public int GetTurnOwnerViewId() => m_turnOwnerViewId;

    public TurnContext GetCurrentTurnContext() => m_currentTurnContext;

    public AllowedTurnActions GetAllowedTurnActions() => m_allowedTurnActions;

    public List<TurnContext> GetTurnHistory() => m_turnHistory;

    private void Start()
    {
        m_currentTurnContext = new TurnContext();
        m_allowedTurnActions = new AllowedTurnActions();
        StartNextTurn();
    }

    private void StartNextTurn()
    {
        if (!PhotonNetwork.IsMasterClient) return;

        m_turnHistory.Add(m_currentTurnContext);

        List<PhotonView> playerList = PlayerManager.I.GetSpawnedPlayerPhotonViews();

        if (playerList.Count <= m_turnIndex)
            m_turnIndex = 0;

        SetTurnOwner(playerList[m_turnIndex]);
        m_turnIndex++;
    }

    public void EndTurn()
    {
        if (!PhotonNetwork.IsMasterClient) return;
        Debug.Log("Ending turn");
        StartNextTurn();
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