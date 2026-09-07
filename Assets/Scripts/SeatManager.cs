using Photon.Pun;
using UnityEngine;

public class SeatManager : NetworkedSingleton<SeatManager>
{
    [SerializeField] private Seat[] _seats;

    public void AssignSeat(PhotonView _photonView)
    {
        photonView.RPC(nameof(AssignSeatRPC), RpcTarget.AllBuffered, _photonView.ViewID);
    }

    [PunRPC]
    private void AssignSeatRPC(int _photonViewID)
    {
        foreach (Seat seat in _seats)
        {
            if (seat.HasAssignedPlayer())
            {
                continue;
            }

            seat.AssignPlayer(_photonViewID);
            return;
        }
    }
}