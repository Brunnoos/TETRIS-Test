using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TetriminoInnerCollider : MonoBehaviour
{
    [SerializeField] private TetriminoBlock m_parentBlock;

    private Collider m_collider;
    private Collider m_collidedWith = null;

    public Collider CollidedWith { get => m_collidedWith; }

    // Start is called before the first frame update
    void Start()
    {
        m_collider = GetComponent<Collider>();
        m_parentBlock.InnerCollider = this;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("SingleBlock"))
        {
            m_collidedWith = collision.collider;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        m_collidedWith = null;
    }
}
