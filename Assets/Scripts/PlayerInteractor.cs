using JetBrains.Annotations;
using Photon.Pun;
using UnityEngine;

public class PlayerInteractor : MonoBehaviourPun
{
    [SerializeField] private Player m_player;
    [SerializeField] private LayerMask m_raycastLayers;

    [CanBeNull] private IInteractable m_currentInteractable;

    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        FireRayFromScreen();
        HandleMouseOverInteractable();
    }

    private void HandleMouseOverInteractable()
    {
        if (m_currentInteractable == null)
        {
            return;
        }

        m_currentInteractable.HandleMouseOver();

        if (Input.GetMouseButtonDown(0))
        {
            m_currentInteractable.AttemptInteract(m_player);
        }
    }

    private void FireRayFromScreen()
    {
        Ray ray = m_player.GetCamera().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, m_raycastLayers))
        {
            HandleRayHit(hit);
            return;
        }

        HandleNoRayHit();
    }

    private void HandleNoRayHit()
    {
        m_currentInteractable = null;
    }

    private void HandleRayHit(RaycastHit _hit)
    {
        if (_hit.collider.TryGetComponent(out IInteractable _interactable))
        {
            HandleInteractableFound(_interactable);
        }
    }

    private void HandleInteractableFound(IInteractable _interactable)
    {
        if (_interactable != null && m_currentInteractable == _interactable)
        {
            return;
        }

        m_currentInteractable = _interactable;
    }
}
