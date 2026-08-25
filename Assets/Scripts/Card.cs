using Photon.Pun;
using TMPro;
using UnityEngine;

public abstract class Card : MonoBehaviourPun
{
    [SerializeField] protected TextMeshProUGUI m_priceText;
    protected int m_originalPrice;
    protected int m_price;
    protected CardType m_type;
    protected MeshRenderer m_meshRenderer;

    public abstract void Initialize(Deck _deck, CardData _cardData);

    protected abstract void SetCardColor();

    public void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
    }

    public void OnMouseUp()
    {
        Debug.Log("OnMouseUp");
    }

    public void OnMouseEnter()
    {
        Debug.Log("OnMouseEnter");
    }

    public void OnMouseUpAsButton()
    {
        Debug.Log("OnMouseUpAsButton");
    }
}