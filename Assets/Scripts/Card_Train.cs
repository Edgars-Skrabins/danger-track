using Photon.Pun;
using TMPro;
using UnityEngine;

public class Card_Train : Card
{
    [SerializeField] private TextMeshProUGUI m_priceText;

    private Deck m_owningDeck;
    private int m_price;
    private CardType m_type;
    private MeshRenderer m_meshRenderer;

    public void Initialize(Deck _deck, TrainCardData _trainCard)
    {
        photonView.RPC(
            nameof(InitializeRPC),
            RpcTarget.AllBuffered,
            _deck.photonView.ViewID,
            _trainCard.cost,
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

    private void SetCardColor()
    {
        m_meshRenderer.sharedMaterial = m_owningDeck.GetCardMaterial(m_type);
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
        m_price += _newPrice;
        m_priceText.text = m_price.ToString();
    }
}