using TMPro;
using UnityEngine;

public class TurnOwnerTest : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_text;
    void Update()
    {
        m_text.text = TurnManager.I.GetTurnOwnerViewId().ToString();
    }
}
