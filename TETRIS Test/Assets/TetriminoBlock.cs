using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CurrentSide { Left, Right, Top, Bottom }

[RequireComponent(typeof(Collider))]
public class TetriminoBlock : MonoBehaviour
{
    #region Inspector

    [SerializeField] private List<Transform> sides;

    #endregion

    #region Internal

    private List<Collider> m_brothersColliders = new List<Collider>();

    private Collider m_collider;
    private Tetrimino m_parentTetrimino;
    private Collider m_wallsHit = null;

    RaycastHit m_targetHit;

    #endregion

    #region Sets & Gets

    public RaycastHit GetTargetHit { get => m_targetHit; }

    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        m_collider = GetComponent<Collider>();
    }

    public void OnSetup(Tetrimino parent, List<Collider> colliders)
    {
        if (colliders.Contains(m_collider))
            colliders.Remove(m_collider);

        m_brothersColliders = colliders;

        m_parentTetrimino = parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("SingleBlock") && m_brothersColliders.Contains(collision.collider))
            return;

        switch(collision.collider.tag)
        {
            case "SingleBlock":
                // Has Hit another Single Block
                if (Mathf.Abs(collision.collider.transform.position.x - transform.position.x) < 0.2f && Mathf.Abs(collision.collider.transform.position.y - transform.position.y) < 0.2f)
                {
                    if (m_wallsHit == null)
                    {
                        if (m_parentTetrimino.transform.position.x < collision.collider.transform.position.x)
                            m_parentTetrimino.OnMoveLeft(true);
                        else
                            m_parentTetrimino.OnMoveRight(true);
                    }
                    else
                    {
                        m_parentTetrimino.OnMoveUp();
                    }

                    return;
                }

                if (Mathf.Abs(collision.collider.transform.position.x - transform.position.x) > 0.2f)
                {
                    if (Mathf.Abs(collision.collider.transform.position.y - transform.position.y) < 0.2f)
                    {
                        // Has hit on the sides -> Check sides to block movement
                        if (collision.collider.transform.position.x > transform.position.x)
                            m_parentTetrimino.CanMoveRight = false;

                        if (collision.collider.transform.position.x < transform.position.x)
                            m_parentTetrimino.CanMoveLeft = false;
                    } 
                }
                else 
                {
                    if (Mathf.Abs(collision.collider.transform.position.y - transform.position.y) > 0.2f)
                    {
                        m_parentTetrimino.HasHitAnotherBlock();
                    }
                    else
                    {
                        // This block is inside another -> Move down and continue if possible
                        m_parentTetrimino.OnAutoMoveDown();
                    }
                }
                break;

            case "BottomBorder":
                m_parentTetrimino.HasHitBottomBorder();
                break;

            case "LeftBorder":
                m_parentTetrimino.CanMoveLeft = false;
                m_wallsHit = collision.collider;
                break;

            case "RightBorder":
                m_parentTetrimino.CanMoveRight = false;
                m_wallsHit = collision.collider;
                break;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("SingleBlock") && m_brothersColliders.Contains(collision.collider))
            return;

        switch (collision.collider.tag)
        {
            case "SingleBlock":
                // Has Hit another Single Block
                if (Mathf.Abs(collision.collider.transform.position.x - transform.position.x) > 0.2f)
                {
                    if (Mathf.Abs(collision.collider.transform.position.y - transform.position.y) < 0.2f)
                    {
                        // Has hit on the sides -> Check sides to block movement
                        if (collision.collider.transform.position.x > transform.position.x)
                            m_parentTetrimino.CanMoveRight = false;

                        if (collision.collider.transform.position.x < transform.position.x)
                            m_parentTetrimino.CanMoveLeft = false;
                    }
                }
                break;

            case "LeftBorder":
                m_parentTetrimino.CanMoveLeft = false;
                m_wallsHit = collision.collider;
                break;

            case "RightBorder":
                m_parentTetrimino.CanMoveRight = false;
                m_wallsHit = collision.collider;
                break;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("SingleBlock") && m_brothersColliders.Contains(collision.collider))
            return;

        switch (collision.collider.tag)
        {
            case "SingleBlock":
                // Has moved away from another SingleBlock
                if (Mathf.Abs(collision.collider.transform.position.x - transform.position.x) > 0.2f)
                {
                    if (Mathf.Abs(collision.collider.transform.position.y - transform.position.y) < 0.2f)
                    {
                        // Has hit on the sides -> Check sides to block movement
                        if (collision.collider.transform.position.x > transform.position.x)
                            m_parentTetrimino.CanMoveRight = true;

                        if (collision.collider.transform.position.x < transform.position.x)
                            m_parentTetrimino.CanMoveLeft = true;
                    }
                }
                break;

            case "LeftBorder":
                m_parentTetrimino.CanMoveLeft = true;
                m_wallsHit = null;
                break;

            case "RightBorder":
                m_parentTetrimino.CanMoveRight = true;
                m_wallsHit = null;
                break;
        }
    }

    public void OnRotateCheck()
    {
        if (m_wallsHit != null && Mathf.Abs(m_wallsHit.transform.position.x - transform.position.x) < 0.2f)
        {
            if (m_wallsHit.CompareTag("LeftBorder"))
            {
                m_parentTetrimino.OnMoveRight(true);
            }
            else if (m_wallsHit.CompareTag("RightBorder"))
            {
                m_parentTetrimino.OnMoveLeft(true);
            }
        }
    }
}
