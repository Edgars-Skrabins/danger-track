using Photon.Pun;
using UnityEngine;

public class Card_Train : Card
{
    [SerializeField] private GameObject m_taxText;
    private Deck_Train m_owningDeck;

    public void Initialize(Deck_Train _deck, TrainCardData _trainCard)
    {
        photonView.RPC(
            nameof(InitializeRPC),
            RpcTarget.AllBuffered,
            _deck.photonView.ViewID,
            _trainCard.cost,
            _trainCard.type);
    }

    private void SetCardColor()
    {
        m_meshRenderer.sharedMaterial = m_owningDeck.GetCardMaterial(m_type);
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

        m_owningDeck = deckView.GetComponent<Deck_Train>();
        m_owningDeck.OnAllCardsPlaced += UpdateTaxStatus;
        m_originalPrice = _price;
        m_price = _price;
        m_type = _type;

        m_priceText.text = m_price.ToString();

        m_meshRenderer ??= GetComponent<MeshRenderer>();
        SetCardColor();
    }

    private void UpdateTaxStatus()
    {
        if (m_owningDeck.GetFirstCardType() == m_type)
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