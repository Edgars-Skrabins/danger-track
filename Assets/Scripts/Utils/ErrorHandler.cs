using UnityEngine;

public static class ErrorHandler
{
    public static void HandlePhotonViewNotFound(int _viewId)
    {
        Debug.LogError($"Could not find Deck PhotonView with ID {_viewId}.");
    }
}
