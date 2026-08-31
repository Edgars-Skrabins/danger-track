using System;
using Photon.Pun;
using UnityEngine;

public class Card_Train : Card
{
    [SerializeField] private GameObject m_taxText;
    private Deck_Train m_owningDeck;

    public override void Initialize(Deck _deck, CardData _cardData)
    {
        photonView.RPC(
            nameof(InitializeRPC),
            RpcTarget.AllBuffered,
            _deck.photonView.ViewID,
            _cardData.numericValue,
            _cardData.type);
    }

    protected override void SetCardColor()
    {
        m_meshRenderer.sharedMaterial = m_owningDeck.GetCardMaterial(m_resourceType);
    }

    public override void HandleMouseOver()
    {
    }

    protected override bool CanInteract(Player _interactor)
    {
        throw new System.NotImplementedException();
    }

    public override void AttemptInteract(Player _interactor)
    {
        if (_interactor.GetResource(m_resourceType) >= m_price)
        {
            _interactor.RemoveResource(m_resourceType, m_price);
            Interact(_interactor);
        }
    }

    protected override void Interact(Player _interactor)
    {
        photonView.RPC(
            nameof(InteractRPC),
            RpcTarget.AllBuffered,
            _interactor.photonView.ViewID);
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

        if(playerView.TryGetComponent(out Player _player))
        {
            _player.AddResource(m_resourceType, m_price);
        }

        RemoveCard();
        TurnManager.I.StartNextTurn();
    }

    [PunRPC]
    private void InitializeRPC(int _deckViewId, int _price, ResourceType _type)
    {
        PhotonView deckView = PhotonView.Find(_deckViewId);

        if (deckView == null)
        {
            Debug.LogError($"Could not find Deck PhotonView with ID {_deckViewId}.");
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

    private void UpdateTaxStatus()
    {
        if (m_owningDeck.GetFirstCardType() == m_resourceType)
        {
            UpdatePrice(m_originalPrice + 1);
            m_taxText.SetActive(true);
            return;
        }

        m_taxText.SetActive(false);
        UpdatePrice(m_originalPrice);
    }

    public void UpdatePrice(int _newPrice)
    {
        photonView.RPC(
            nameof(UpdatePriceRPC),
            RpcTarget.All,
            _newPrice);
    }

    [PunRPC]
    private void UpdatePriceRPC(int _newPrice)
    {
        m_price = _newPrice;
        m_priceText.text = m_price.ToString();
    }
}
