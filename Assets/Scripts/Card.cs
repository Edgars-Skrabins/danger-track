using Photon.Pun;
using UnityEngine;

public abstract class Card : MonoBehaviourPun
{
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