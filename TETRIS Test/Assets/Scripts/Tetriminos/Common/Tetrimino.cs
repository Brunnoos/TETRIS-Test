using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoleDirection { North, East, South, West }

public class Tetrimino : MonoBehaviour
{
    #region Inspector

    [SerializeField] private Vector2 spawnPointModifier;
    [SerializeField] private Vector2 gridStart;
    [SerializeField] private PoleDirection currentDirection;
    [SerializeField] private TetriminoBlock pivotBlock;
    [SerializeField] private List<TetriminoBlock> remainingBlocks;

    #endregion

    #region Internal

    private bool m_isDone = false;

    private List<TetriminoBlock> m_allBlocks = new List<TetriminoBlock>();

    private PoleDirection m_previousDirection = PoleDirection.North;

    #endregion

    #region Sets & Gets 

    public TetriminoBlock GetPivotBlock { get => pivotBlock; }
    public List<TetriminoBlock> GetRemainingBlocks { get => remainingBlocks; }
    public List<TetriminoBlock> GetAllBlocks { get => m_allBlocks; }

    #endregion

    #region UNITY

    public void Update()
    {
        if (!m_isDone)
            Rotate();
    }

    #endregion  

    #region Setup

    public void Initialize(Vector3 startPoint)
    {
        transform.position = startPoint + (Vector3)spawnPointModifier;
        OnSetupBlocks();
        OnUpdatePlayfield();
    }

    public void OnSetupBlocks()
    {
        pivotBlock.OnPivotSetup(gridStart, this);
        m_allBlocks.Add(pivotBlock);

        foreach (TetriminoBlock block in remainingBlocks)
        {
            block.OnSetup(gridStart, pivotBlock, this);
            m_allBlocks.Add(block);
        }
    }

    public void OnUpdatePlayfield(bool blockNewPosition = false)
    {
        GameManager.Instance.GetPlayfield.OnTetriminoMoved(m_allBlocks, blockNewPosition);
    }

    #endregion

    #region Movement

    public void ChangeDirection(bool clockwise = true)
    {
        if (clockwise)
            currentDirection = (currentDirection == PoleDirection.West) ? PoleDirection.North : (PoleDirection)((int)currentDirection + 1);
        else
            currentDirection = (currentDirection == PoleDirection.North) ? PoleDirection.West : (PoleDirection)((int)currentDirection - 1);
    }

    private void Rotate()
    { 
        // If a new Rotation is desired
        if (m_previousDirection != currentDirection)
        {
            // First, try to rotate normally
            if (TryRotate((int)currentDirection))
            {
                pivotBlock.OnRotate((int)currentDirection);

                foreach (TetriminoBlock block in remainingBlocks)
                {
                    block.OnRotate((int)currentDirection);
                }

                m_previousDirection = currentDirection;
                OnUpdatePlayfield();

                GameManager.Instance.OnUpdateGhost();
            }  
            // If not possible, try to move piece after the desired rotation
            else
            {
                Vector2 possibleRightMove = TryMoveAfterRotation(Vector2.right);
                Vector2 possibleLeftMove = TryMoveAfterRotation(Vector2.left);

                Vector2 choosenMove = GetPriorityMove(possibleLeftMove, possibleRightMove);

                if (choosenMove != Vector2.zero)
                {
                    pivotBlock.OnRotate((int)currentDirection);

                    foreach (TetriminoBlock block in remainingBlocks)
                    {
                        block.OnRotate((int)currentDirection);
                    }

                    m_previousDirection = currentDirection;
                    OnUpdatePlayfield(true);

                    Move(choosenMove);

                    GameManager.Instance.OnUpdateGhost();
                }
                else 
                {
                    // If nothing is possible, no rotation is done
                    currentDirection = m_previousDirection;
                }

            }
        }        
    }

    public void Move(Vector2 direction)
    {
        bool test = TryMove(direction);

        // If movement is possible after check, do it
        if (test)
        {
            transform.position += (Vector3)direction;

            pivotBlock.OnMove(direction);

            foreach (TetriminoBlock block in remainingBlocks)
            {
                block.OnMove(direction);
            }

            OnUpdatePlayfield();

            if (direction != Vector2.down)
                GameManager.Instance.OnUpdateGhost();
        } 
        else
        {
            // If a Down movement is not possible, nothing should be done and the piece is locked
            if (!m_isDone && direction == Vector2.down)
            {
                // Reached Bottom
                m_isDone = true;
                GameManager.Instance.OnTetriminoDone();
            }
        }
    }

    #endregion

    #region Collision Handle

    private bool TryRotate(int direction)
    {
        bool success = true;

        foreach(TetriminoBlock block in m_allBlocks)
        {
            if (!block.TryRotate(direction, m_allBlocks))
            {
                success = false;
                break;
            }            
        }

        return success;
    }

    private bool TryMove(Vector2 direction)
    {
        bool success = true;

        foreach (TetriminoBlock block in m_allBlocks)
        {
            if (!block.TryMove(direction, m_allBlocks))
            {
                success = false;
                break;
            }
        }

        return success;
    }

    private Vector2 TryMoveAfterRotation(Vector2 direction)
    {
        Vector2 currentDirectionTested = direction;
        int maxLength = (direction == Vector2.up) ? GetVerticalLength(true) / 2 : GetHorizontalLength(true) / 2;

        for (int i = 1; i <= maxLength; i++)
        {
            bool success = true;

            currentDirectionTested *= i;

            foreach (TetriminoBlock block in m_allBlocks)
            {
                if (!block.TryMove(direction, m_allBlocks, true))
                {
                    success = false;
                    break;
                }
            }

            if (success)
            {
                return currentDirectionTested;
            }
        }

        return Vector2.zero;
    }

    private int GetHorizontalLength(bool tempPosition = false)
    {
        List<int> xCoordFound = new List<int>();

        foreach (TetriminoBlock block in m_allBlocks)
        {
            int foundCoord = (!tempPosition) ? (int)block.GridPosition.x : (int)block.GetTempGridPosition.x;

            if (!xCoordFound.Contains(foundCoord))
                xCoordFound.Add(foundCoord);
        }

        return xCoordFound.Count;
    }

    private int GetVerticalLength(bool tempPosition = false)
    {
        List<int> yCoordFound = new List<int>();

        foreach (TetriminoBlock block in m_allBlocks)
        {
            int foundCoord = (!tempPosition) ? (int)block.GridPosition.y : (int)block.GetTempGridPosition.y;

            if (!yCoordFound.Contains(foundCoord))
                yCoordFound.Add(foundCoord);
        }

        return yCoordFound.Count;
    }

    private Vector2 GetPriorityMove(Vector2 left, Vector2 right)
    {
        // Right Move is top priority for a clockwise movement
        if (right != Vector2.zero)
            return right;

        if (left != Vector2.zero)
            return left;

        return Vector2.zero;
    }

    #endregion

    #region

    public void OnBlockDeleted(TetriminoBlock block)
    {
        if (m_allBlocks.Contains(block))
            m_allBlocks.Remove(block);

        if (remainingBlocks.Contains(block))
            remainingBlocks.Remove(block);

        if (pivotBlock == block)
            pivotBlock = null;
    }

    #endregion
}