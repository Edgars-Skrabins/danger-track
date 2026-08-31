using Photon.Pun;

public partial class TurnManager
{
    [PunRPC]
    private void SetTurnOwnerRPC(int _viewId)
    {
        m_turnOwnerViewId = _viewId;
        OnTurnOwnerChange?.Invoke();
    }
}
