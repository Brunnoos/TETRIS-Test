using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BlocksPositions
{
    public Transform pivotPoint;
    public List<BlockPosition> northPosition;
    public List<BlockPosition> eastPosition;
    public List<BlockPosition> southPosition;
    public List<BlockPosition> westPosition;
}

public class Tetrimino : MonoBehaviour
{
    private enum PivotPosition { OnGridLine, InsideGrid }

    [SerializeField] private PoleDirection currentDirection;
    [SerializeField] private BlocksPositions rotationPositions;

    [SerializeField] private Transform rotationPivot;
    [SerializeField] private PivotPosition pivotPosition;
    [SerializeField] private List<TetriminoBlock> blocks;

    private List<TetriminoBlock> m_blocksToRaycast = new List<TetriminoBlock>();

    private bool m_canMoveDown = true;
    private bool m_canMoveLeft = true;
    private bool m_canMoveRight = true;

    private int m_lastRotationDirection = 0;

    private bool m_hasHandledThisFrame = false;
    private Collider m_colliderWithThisFrame = null;
    private bool m_rotatedThisFrame = false;

    private bool _isDone = false;

    #region Sets & Gets 

    public bool CanMoveDown { get => m_canMoveDown; set => m_canMoveDown = value; }
    public bool CanMoveLeft { get => m_canMoveLeft; set => m_canMoveLeft = value; }
    public bool CanMoveRight { get => m_canMoveRight; set => m_canMoveRight = value; }

    #endregion

    public void Awake()
    {
        SetupBlocks();
    }

    public void Start()
    {
        //SetupBlocks();
    }

    public void Update()
    {
        Rotate();
    }

    public void LateUpdate()
    {        
        if (!m_hasHandledThisFrame)
        {
            CheckForCollisions();

            CheckForStop();
        }        
        m_rotatedThisFrame = false;

        if (m_hasHandledThisFrame == true)
            m_hasHandledThisFrame = false;
    }

    #region Blocks

    public void SetupBlocks()
    {
        List<Collider> blockColliders = new List<Collider>();

        foreach(TetriminoBlock block in blocks)
        {
            blockColliders.Add(block.GetComponent<Collider>());
        }

        foreach(TetriminoBlock block in blocks)
        {
            block.OnSetup(this, blockColliders, OnRotateBack);
        }
    }

    public void HasHitAnotherBlock()
    {
        m_canMoveDown = false;

        if (!_isDone)
        {
            _isDone = true;
            GameManager.Instance.OnChooseTetriminoToSpawn();
        }        
    }

    public void HasHitBottomBorder()
    {
        CheckForCollisions();
        m_canMoveDown = false;

        if (!_isDone)
        {
            _isDone = true;
            GameManager.Instance.OnChooseTetriminoToSpawn();
        }
    }

    public void CheckForStop()
    {
        foreach (TetriminoBlock block in blocks)
        {
            if (block.GetCantMoveDown)
            {
                HasHitBottomBorder();
                break;
            }
        }
    }

    public void CheckForCollisions()
    {
        if (!_isDone)
        {
            TetriminoBlock blockWithCollision = null;

            foreach (TetriminoBlock block in blocks)
            {
                if (block.InnerCollider.CollidedWith != null)
                {
                    blockWithCollision = block;
                    break;
                }
            }

            if (blockWithCollision != null)
            {
                HandleCollision(blockWithCollision, blockWithCollision.InnerCollider.CollidedWith);
                m_hasHandledThisFrame = true;
                //CheckForCollisions();
            }
        }        
    }

    public void HandleCollision(TetriminoBlock source, Collider collider)
    {        
        switch(collider.tag)
        {
            case "InnerCollider":
                {                    
                    //// This collision has been made through a Rotation
                    bool canMoveLeft = true;
                    bool canMoveRight = true;

                    foreach (TetriminoBlock child in blocks)
                    {
                        if (child.CheckDirection(Vector3.right) != null)
                            canMoveRight = false;

                        if (child.CheckDirection(Vector3.left) != null)
                            canMoveLeft = false;
                    }

                    if (!canMoveLeft && !canMoveRight)
                    {
                        OnRotateBack();
                    }
                    else if (canMoveLeft)
                    {
                        OnMoveLeft(true);
                    }
                    else if (canMoveRight)
                    {
                        OnMoveRight(true);
                    }

                    break;
                }

            case "LeftBorder":
                {
                    bool canMove = true;

                    foreach (TetriminoBlock child in blocks)
                    {
                        if (child.CheckDirection(Vector3.right) != null)
                        {
                            canMove = false;
                        }
                    }

                    if (!canMove)
                    {
                        OnRotateBack();
                    }
                    else
                    {
                        OnMoveRight(true);
                    }

                    break;
                }                    

            case "RightBorder":
                {
                    bool canMove = true;

                    foreach (TetriminoBlock child in blocks)
                    {
                        if (child.CheckDirection(Vector3.left) != null)
                        {
                            canMove = false;
                        }
                    }

                    if (!canMove)
                    {
                        OnRotateBack();
                    }
                    else
                    {
                        OnMoveLeft(true);
                    }

                    break;
                }

            case "BottomBorder":
                OnMoveUp();
                break;
                    
        } 
        
    }

    #endregion

    #region Movement

    public void Rotate()
    {
        switch (currentDirection)
        {
            case PoleDirection.North:
                for (int i = 0; i < blocks.Count; i++)
                {
                    blocks[i].OnPosition(rotationPositions.pivotPoint.position, rotationPositions.northPosition[i].relativeIndexes);
                }

                break;
            case PoleDirection.East:
                for (int i = 0; i < blocks.Count; i++)
                {
                    blocks[i].OnPosition(rotationPositions.pivotPoint.position, rotationPositions.eastPosition[i].relativeIndexes);
                }

                break;
            case PoleDirection.South:
                for (int i = 0; i < blocks.Count; i++)
                {
                    blocks[i].OnPosition(rotationPositions.pivotPoint.position, rotationPositions.southPosition[i].relativeIndexes);
                }

                break;
            case PoleDirection.West:
                for (int i = 0; i < blocks.Count; i++)
                {
                    blocks[i].OnPosition(rotationPositions.pivotPoint.position, rotationPositions.westPosition[i].relativeIndexes);
                }

                break;
        }
    }
    public void OnAutoMoveDown()
    {
        if (m_canMoveDown)
        {
            transform.position -= new Vector3(0, 1);
            m_rotatedThisFrame = false;
        }        
    }

    public void OnMoveUp()
    {
        transform.position += new Vector3(0, 1);
    }

    public void OnRotate(bool clockwise)
    {
        m_lastRotationDirection = (clockwise) ? -90 : 90;
        rotationPivot.Rotate(new Vector3(0, 0, m_lastRotationDirection));

        foreach(TetriminoBlock block in blocks)
        {
            block.OnRotate(clockwise);
            //block.OnRotateCheck(OnRotateBack);
        }

        CheckForCollisions();
    }

    private void OnRotateBack()
    {
        rotationPivot.Rotate(new Vector3(0, 0, -1 * m_lastRotationDirection));
    }

    public void OnMoveLeft(bool forceMove = false)
    {
        if (CanMoveLeft || forceMove)
            transform.position -= new Vector3(1, 0);
    }

    public void OnMoveRight(bool forceMove = false)
    {
        if (CanMoveRight || forceMove)
            transform.position += new Vector3(1, 0);
    }



    #endregion
}
