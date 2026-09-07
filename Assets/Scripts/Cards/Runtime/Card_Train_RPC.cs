using Photon.Pun;
using UnityEngine;

public partial class Card_Train
{
    [PunRPC]
    private void InitializeRPC(int _deckViewId, int _price, ResourceType _type)
    {
        PhotonView deckView = PhotonView.Find(_deckViewId);

        if (deckView == null)
        {
            ErrorHandler.HandlePhotonViewNotFound(_deckViewId);
            return;
        }

        m_owningDeck = deckView.GetComponent<Deck_Train>();
        m_owningDeck.OnAllCardsPlaced += UpdateTaxStatus;

        m_originalPrice = _price;
        m_price = _price;

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
        {
            player.RemoveResource(m_resourceType, m_price);
            player.AddTrainCard(m_resourceType, m_originalPrice);
        }
        RemoveCard();
        GameEvents.RaiseTrainCardPickup(m_resourceType);
    }

    [PunRPC]
    private void UpdatePriceRPC(int _newPrice)
    {
        m_price = _newPrice;
        m_priceText.text = m_price.ToString();
    }
}
