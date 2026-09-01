using Photon.Pun;
using UnityEngine;

public partial class Card_Resource : Card
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

    protected override void SetCardColor()
    {
        m_meshRenderer.sharedMaterial = m_owningDeck.GetCardMaterial(m_resourceType);
    }

    public override void HandleMouseOver() { }

    protected override bool CanInteract(Player _interactor) => TurnManager.I.GetAllowedTurnActions().CanPickupResourceCards;

    public override void AttemptInteract(Player _interactor)
    {
        if (!CanInteract(_interactor)) return;

        Interact(_interactor);
    }

    protected override void Interact(Player _interactor)
    {
        photonView.RPC(
            nameof(InteractRPC),
            RpcTarget.AllBuffered,
            _interactor.photonView.ViewID);
    }
}
