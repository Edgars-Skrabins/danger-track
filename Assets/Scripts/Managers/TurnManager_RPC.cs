using Photon.Pun;

public partial class TurnManager
{
    [PunRPC]
    private void SetTurnOwnerRPC(int _viewId)
    {
        m_turnOwnerViewId = _viewId;
        m_currentTurnContext = new TurnContext();
        m_allowedTurnActions.Reset();
        OnTurnOwnerChange?.Invoke();
    }
}
