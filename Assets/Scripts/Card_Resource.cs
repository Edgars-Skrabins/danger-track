using Photon.Pun;
using UnityEngine;

public class Card_Resource : Card
{
    private Deck_Resource m_owningDeck;

    public override void Initialize(Deck _deck, CardData _cardData)
    {
        photonView.RPC(
            nameof(InitializeRPC),
            RpcTarget.AllBuffered,
            _deck.photonView.ViewID,
            _cardData.numericValue,
            _cardData.type);
    }

    [PunRPC]
    private void InitializeRPC(int _deckViewId, int _price, ResourceType _type)
    {
        PhotonView deckView = PhotonView.Find(_deckViewId);

        if (!deckView)
        {
            ErrorHandler.HandlePhotonViewNotFound(_deckViewId);
            return;
        }

        m_owningDeck = deckView.GetComponent<Deck_Resource>();
        m_price = _price;
        m_resourceType = _type;

        m_priceText.text = m_price.ToString();

        m_meshRenderer ??= GetComponent<MeshRenderer>();
        SetCardColor();
    }

    protected override void SetCardColor()
    {
        m_meshRenderer.sharedMaterial = m_owningDeck.GetCardMaterial(m_resourceType);
    }

    public override void HandleMouseOver()
    {

    }

    public override void AttemptInteract(Player _interactor)
    {
        Interact(_interactor);
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

    }
}
