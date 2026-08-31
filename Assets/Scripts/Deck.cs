using System;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using UnityEngine;

[Serializable] public class CardMaterialMapping
{
    public ResourceType type;
    public Material material;
}

public abstract class Deck : MonoBehaviourPun
{
    public event Action OnAllCardsPlaced;
    [SerializeField] private Transform[] m_cardSlots;
    [SerializeField] private CardMaterialMapping[] m_cardMaterials;

    private void Start()
    {
        TurnManager.I.OnTurnOwnerChange += PopulateDeck;
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

        for (int i = 0; i < m_cardSlots.Length; i++)
        {
            if (IsSlotOccupied(i))
            {
                continue;
            }
            PlaceCardInSlot(m_cardSlots[i], i);
        }
        OnAllCardsPlaced?.Invoke();
    }

    protected abstract void PlaceCardInSlot(Transform _cardSlot, int _slotIndex);
    protected abstract bool IsSlotOccupied(int _slotIndex);

    public Material GetCardMaterial(ResourceType type)
    {
        return m_cardMaterials.First(x => x.type == type).material;
    }
}
