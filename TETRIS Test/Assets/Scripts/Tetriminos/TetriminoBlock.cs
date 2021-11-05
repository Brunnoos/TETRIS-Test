using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PoleDirection { North, East, South, West }

[RequireComponent(typeof(Collider))]
public class TetriminoBlock : MonoBehaviour
{
    #region Inspector

    [SerializeField] private List<Transform> sides;

    #endregion

    #region Internal

    private PoleDirection m_currentRotation = PoleDirection.North;
    private Vector3 m_internalRotation = Vector3.up;

    private List<Collider> m_brothersColliders = new List<Collider>();

    private Collider m_collider;
    private TetriminoInnerCollider m_innerCollider;
    private Tetrimino m_parentTetrimino;
    private Collider m_collidedWith = null;

    private bool m_cantMoveDown = false;

    private System.Action m_onRotateBack;

    RaycastHit m_targetHit;

    // This considers rotation -> Side rotates with cube
    private Collider m_collidedWithTop = null;
    private Collider m_collidedWithRight = null;
    private Collider m_collidedWithBottom = null;
    private Collider m_collidedWithLeft = null;

    #endregion

    #region Sets & Gets

    public RaycastHit GetTargetHit { get => m_targetHit; }

    public TetriminoInnerCollider InnerCollider { get => m_innerCollider; set => m_innerCollider = value; }

    public bool GetCantMoveDown { get => m_cantMoveDown; }

    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        m_collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (m_collidedWith != null)
        //{
        //    m_parentTetrimino.HandleCollision(this, m_collidedWith);
        //    m_collidedWith = null;
        //}
    }

    public void OnSetup(Tetrimino parent, List<Collider> colliders, System.Action rotateBack)
    {
        if (colliders.Contains(m_collider))
            colliders.Remove(m_collider);

        m_brothersColliders = colliders;

        m_parentTetrimino = parent;

        m_onRotateBack = rotateBack;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("SingleBlock") && m_brothersColliders.Contains(collision.collider))
            return;

        m_collidedWith = collision.collider;

        switch (collision.collider.tag)
        {
            case "SingleBlock":
                // Has Hit another Single Block

                if (Mathf.Abs(collision.collider.transform.position.x - transform.position.x) < 0.2f && Mathf.Abs(collision.collider.transform.position.y - transform.position.y) < 0.2f)
                {
                    return;
                }

                if (Mathf.Abs(collision.collider.transform.position.x - transform.position.x) > 0.2f && Mathf.Abs(collision.collider.transform.position.y - transform.position.y) > 0.2f)
                {
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
                else if (transform.position.y - collision.collider.transform.position.y > 0.2f)
                {
                    m_cantMoveDown = true;
                }
                break;

            case "BottomBorder":
                //m_parentTetrimino.HasHitBottomBorder();
                m_cantMoveDown = true;
                break;

            case "LeftBorder":
                m_parentTetrimino.CanMoveLeft = false;
                break;

            case "RightBorder":
                m_parentTetrimino.CanMoveRight = false;
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
                //if (Mathf.Abs(collision.collider.transform.position.x - transform.position.x) > 0.2f)
                //{
                //    if (Mathf.Abs(collision.collider.transform.position.y - transform.position.y) < 0.2f)
                //    {
                //        // Has hit on the sides -> Check sides to block movement
                //        if (collision.collider.transform.position.x > transform.position.x)
                //            m_parentTetrimino.CanMoveRight = false;

                //        if (collision.collider.transform.position.x < transform.position.x)
                //            m_parentTetrimino.CanMoveLeft = false;
                //    }
                //}
                break;

            case "LeftBorder":
                //m_parentTetrimino.CanMoveLeft = false;
                break;

            case "RightBorder":
                //m_parentTetrimino.CanMoveRight = false;
                break;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("SingleBlock") && m_brothersColliders.Contains(collision.collider))
            return;

        if (m_collidedWith != null && m_collidedWith == collision.collider)
            m_collidedWith = null;

        switch (collision.collider.tag)
        {
            case "SingleBlock":

                //// Has moved away from another SingleBlock
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
                else if (m_cantMoveDown)
                    m_cantMoveDown = false;
                break;

            case "LeftBorder":
                m_parentTetrimino.CanMoveLeft = true;
                break;

            case "RightBorder":
                m_parentTetrimino.CanMoveRight = true;
                break;
        }
    }

    public void OnRotate(bool clockwise)
    {
        Quaternion rotation = Quaternion.Euler(0, 0, (clockwise) ? -90 : 90);
        m_internalRotation = rotation * m_internalRotation;      
    }

    public void OnInnerCollided(Collision collision)
    {
        m_parentTetrimino.HandleCollision(this, collision.collider);
    }

    public Collider CheckDirection(Vector3 direction)
    {
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;

        Physics.Raycast(ray, out hit, 1.5f);

        if (hit.collider != null && (hit.collider.CompareTag("InnerCollider") || hit.collider.CompareTag("SingleBlock")) && m_brothersColliders.Contains(hit.collider))
            return null;

        return hit.collider;
    }

    public void AskForCheck()
    {
        m_parentTetrimino.CheckForCollisions();
    }

    //public void CheckAround()
    //{
    //    m_collidedWithTop = CheckColliderCorrected(Vector3.up);
    //    m_collidedWithRight = CheckColliderCorrected(Vector3.right);
    //    m_collidedWithBottom = CheckColliderCorrected(Vector3.down);
    //    m_collidedWithLeft = CheckColliderCorrected(Vector3.left);
    //}

    //public Collider CheckColliderCorrected(Vector3 direction)
    //{
    //    Ray ray;
    //    RaycastHit hit;
    //    float rotationDifference;

    //    rotationDifference = Vector3.Angle(direction, m_internalRotation);
    //    Vector3 directionCorrected = Quaternion.Euler(0, 0, rotationDifference) * direction;

    //    ray = new Ray(transform.position, directionCorrected);

    //    if (Physics.Raycast(ray, out hit, 1.5f))
    //    {
    //        return hit.collider;
    //    }

    //    return null;
    //}
}
