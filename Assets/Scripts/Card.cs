using Photon.Pun;
using TMPro;
using UnityEngine;

public abstract class Card : MonoBehaviourPun
{
    [SerializeField] protected TextMeshProUGUI m_priceText;
    protected int m_price;
    protected Deck m_owningDeck;
    protected CardType m_type;
    protected MeshRenderer m_meshRenderer;

    protected void SetCardColor()
    {
        m_meshRenderer.sharedMaterial = m_owningDeck.GetCardMaterial(m_type);
    }

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