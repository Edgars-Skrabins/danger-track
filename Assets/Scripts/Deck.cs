using System;
using System.Linq;
using Photon.Pun;
using UnityEngine;

[Serializable] public class CardMaterialMapping
{
    public CardType type;
    public Material material;
}

public abstract class Deck : MonoBehaviourPun
{
    public event Action OnAllCardsPlaced;
    [SerializeField] private Transform[] m_cardSlots;
    [SerializeField] private CardMaterialMapping[] m_cardMaterials;

    private void Start()
    {
        PopulateDeck();
        PlaceAllCards();
    }

    public abstract void PopulateDeck();

    public void PlaceAllCards()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }

        foreach (Transform cardSlot in m_cardSlots)
        {
            PlaceCardInSlot(cardSlot);
        }

        OnAllCardsPlaced?.Invoke();
    }

    protected abstract void PlaceCardInSlot(Transform _cardSlot);

    public Material GetCardMaterial(CardType type)
    {
        return m_cardMaterials.First(x => x.type == type).material;
    }
}