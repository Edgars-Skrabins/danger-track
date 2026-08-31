using System;
using Photon.Pun;
using TMPro;
using UnityEngine;

public abstract class Card : MonoBehaviourPun, IInteractable
{
    public event Action OnCardRemoved;
    [SerializeField] protected TextMeshProUGUI m_priceText;
    protected int m_originalPrice;
    protected int m_price;
    protected ResourceType m_resourceType;
    protected MeshRenderer m_meshRenderer;

    public abstract void Initialize(Deck _deck, CardData _cardData);

    protected abstract void SetCardColor();

    public abstract void HandleMouseOver();

    public abstract void AttemptInteract(Player _interactor);
    protected abstract void Interact(Player _interactor);
    protected abstract bool CanInteract(Player _interactor);

    protected virtual void RemoveCard()
    {
        OnCardRemoved?.Invoke();
        Destroy(gameObject);
    }

}
