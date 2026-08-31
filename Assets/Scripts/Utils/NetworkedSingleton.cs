using Photon.Pun;
using UnityEngine;

public class NetworkedSingleton<T> : MonoBehaviourPun where T : MonoBehaviourPun
{
    public static T I {get; private set;}

    [SerializeField] private bool m_dontDestroyOnLoad;

    protected virtual void Awake()
    {
        if (I == null)
        {
            I = this as T;
            if (m_dontDestroyOnLoad)
                DontDestroyOnLoad(gameObject);
        }
        else if (I != null && I != this)
        {
            Debug.LogError("There's more than one singleton " + gameObject.name + " of type " + GetType());
            Destroy(gameObject);
        }
    }
}
