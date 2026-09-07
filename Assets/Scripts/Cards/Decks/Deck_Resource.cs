using Photon.Pun;

public class Deck_Resource : Deck<Card_Resource, ResourceCardData, ResourceDeckContent, ResourceDeckCardPool>
{
    public override void HandleMouseOver()
    {
    }

    public override void AttemptInteract(Player _interactor)
    {
        if (TurnManager.I.GetCurrentTurnContext().GetPickedUpCardCount() >= 2) return;

        ResourceCardData topCard = GetTopCardFromDeck();
        if (topCard == null) return;

        photonView.RPC(
            nameof(PickCardFromDeckRPC),
            RpcTarget.AllBuffered,
            _interactor.photonView.ViewID,
            topCard.type,
            topCard.numericValue);
    }

    [PunRPC]
    private void PickCardFromDeckRPC(int _playerViewId, ResourceType _resourceType, int _price)
    {
        PhotonView playerView = PhotonView.Find(_playerViewId);

        if (!playerView)
        {
            ErrorHandler.HandlePhotonViewNotFound(_playerViewId);
            return;
        }

        if (playerView.TryGetComponent(out Player player))
            player.AddResource(_resourceType, _price);

        m_cardsInDeck.RemoveAt(0);

        CardPickupSystem.RaiseCardPickup(_resourceType, true);
    }
}