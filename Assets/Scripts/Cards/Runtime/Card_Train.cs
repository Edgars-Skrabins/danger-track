using Photon.Pun;
using UnityEngine;

public partial class Card_Train : Card
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

    public override void HandleMouseOver() { }

    protected override bool CanInteract(Player _interactor)
    {
        if (TurnManager.I.GetCurrentTurnContext().WasResourcePickedUp()) return false;
        return _interactor.GetResource(m_resourceType) >= m_price;
    }

    public override void AttemptInteract(Player _interactor)
    {
        if (!CanInteract(_interactor)) return;

        if (_interactor.GetResource(m_resourceType) >= m_price)
        {
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

    public void UpdatePrice(int _newPrice)
    {
        photonView.RPC(
            nameof(UpdatePriceRPC),
            RpcTarget.All,
            _newPrice);
    }

    private void UpdateTaxStatus()
    {
        return;
        if (m_owningDeck.GetFirstCardType() == m_resourceType)
        {
            UpdatePrice(m_originalPrice + 1);
            m_taxText.SetActive(true);
            return;
        }

        m_taxText.SetActive(false);
        UpdatePrice(m_originalPrice);
    }
}
