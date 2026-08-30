using UnityEngine;

public interface IInteractable
{
    public void HandleMouseOver();
    public void AttemptInteract(Player _interactor);
    protected void Interact();
}
