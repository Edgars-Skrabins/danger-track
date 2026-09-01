using Photon.Pun;
using UnityEngine;

public partial class Card_Resource
{
    [PunRPC]
    private void InitializeRPC(int _deckViewId, int _price, ResourceType _type)
    {
        PhotonView deckView = PhotonView.Find(_deckViewId);

        if (!deckView)
        {
            ErrorHandler.HandlePhotonViewNotFound(_deckViewId);
            return;
        }

        m_owningDeck   = deckView.GetComponent<Deck_Resource>();
        m_price        = _price;
        m_resourceType = _type;

        m_priceText.text = m_price.ToString();

        m_meshRenderer ??= GetComponent<MeshRenderer>();
        SetCardColor();
    }

    [PunRPC]
    private void InteractRPC(int _playerViewId)
    {
        PhotonView playerView = PhotonView.Find(_playerViewId);

        if (!playerView)
        {
            ErrorHandler.HandlePhotonViewNotFound(_playerViewId);
            return;
        }

        if (playerView.TryGetComponent(out Player player))
            player.AddResource(m_resourceType, m_price);

        RemoveCard();
        CardPickupSystem.I.RaiseCardPickup(m_resourceType);
    }
}
