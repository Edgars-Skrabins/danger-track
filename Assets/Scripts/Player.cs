using Photon.Pun;
using UnityEngine;

public class Player : MonoBehaviourPun
{
    private Rigidbody m_rigidbody;
    [SerializeField] private float m_moveSpeed;

    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        Move();
    }

    private void Move()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(movementX, 0f, movementZ).normalized;

        m_rigidbody.MovePosition(
            m_rigidbody.position + movement * (m_moveSpeed * Time.deltaTime)
        );
    }
}