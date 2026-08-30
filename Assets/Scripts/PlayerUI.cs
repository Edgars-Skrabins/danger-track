using System;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Player m_player;
    private void Start()
    {
        m_player.OnResourceUpdate += UpdateResourceUI;
    }

    private void UpdateResourceUI()
    {

    }

    private void OnDestroy()
    {
        m_player.OnResourceUpdate -= UpdateResourceUI;
    }
}
