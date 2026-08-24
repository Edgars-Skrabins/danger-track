using Photon.Pun;
using UnityEngine;

public class Card_Resource : Card
{
    public void Initialize(Deck _deck, ResourceCardData _trainCard)
    {
        photonView.RPC(
            nameof(InitializeRPC),
            RpcTarget.AllBuffered,
            _deck.photonView.ViewID,
            _trainCard.value,
            _trainCard.type);
    }

    [PunRPC]
    private void InitializeRPC(int _deckViewId, int _price, CardType _type)
    {
        PhotonView deckView = PhotonView.Find(_deckViewId);

        if (deckView == null)
        {
            Debug.LogError($"Could not find Deck PhotonView with ID {_deckViewId}.");
            return;
        }

        m_owningDeck = deckView.GetComponent<Deck>();
        m_price = _price;
        m_type = _type;

        m_priceText.text = m_price.ToString();

        m_meshRenderer ??= GetComponent<MeshRenderer>();
        SetCardColor();
    }
}