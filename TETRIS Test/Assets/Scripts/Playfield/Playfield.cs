using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playfield : MonoBehaviour
{
    #region Inspector

    [SerializeField] private int gridXSize = 10;
    [SerializeField] private int gridYSize = 40;
    [SerializeField] private Transform spawnPoint;

    [Space(20)]
    [SerializeField] private Vector3 gridGizmosModifier;

    #endregion

    #region Internal

    private Dictionary<Vector2, TetriminoBlock> m_gridLayout = new Dictionary<Vector2, TetriminoBlock>(); // True => Has Block | False => Is Empty

    #endregion

    #region Sets & Gets

    public Transform SpawnPoint { get => spawnPoint; }

    #endregion

    #region UNITY

    private void Awake()
    {
        SetupGridLayout();
    }

    #endregion

    #region Grid Handler

    private void SetupGridLayout()
    {
        m_gridLayout = new Dictionary<Vector2, TetriminoBlock>();
        for(int x = 0; x < gridXSize; x++)
        {
            for(int y = 0; y < gridYSize; y++)
            {
                m_gridLayout.Add(new Vector2(x, y), null);
            }
        }
    }

    public void ResetPlayfield()
    {
        SetupGridLayout();
    }

    public void OnTetriminoMoved(List<TetriminoBlock> blocks, bool blockNewPosition = false)
    {
        List<Vector2> previousPosList = new List<Vector2>();
        Dictionary<Vector2, TetriminoBlock> newPosList = new Dictionary<Vector2, TetriminoBlock>();

        foreach(TetriminoBlock block in blocks)
        {
            Vector2 previousPos = block.PreviousGridPosition;
            Vector2 newPos = block.GridPosition;

            if (previousPos.x >= 0 && previousPos.x < gridXSize && previousPos.y >= 0 && previousPos.y < gridYSize)
                previousPosList.Add(previousPos);

            if (!blockNewPosition)
                newPosList.Add(newPos, block);
        } 

        foreach(Vector2 previousPos in previousPosList)
        {
            m_gridLayout[previousPos] = null;
        }

        foreach (Vector2 newPos in newPosList.Keys)
        {
            m_gridLayout[newPos] = newPosList[newPos];
        }
    }

    public bool CheckGridSlotFree(Vector2 testPosition, List<TetriminoBlock> ignoredBlocks)
    {
        if (testPosition.x < 0 || testPosition.x >= gridXSize)
            return false;

        if (testPosition.y < 0 || testPosition.y >= gridYSize)
            return false;

        if (m_gridLayout[testPosition] == null)
            return true;

        foreach (TetriminoBlock block in ignoredBlocks)
        {
            if (m_gridLayout[testPosition] == block)
                return true;
        }

        return false;
    }

    // Returns True if all Tetrimino Points in Spawn are empty and it can be spawned
    public bool CheckTetriminoSpawnPoints(List<TetriminoBlock> blocks)
    {
        bool result = true;

        foreach(TetriminoBlock block in blocks)
        {
            if (!CheckGridSlotFree(block.GridPosition, blocks))
            {
                result = false;
                break;
            }
        }

        return result;
    }

    #endregion

    #region Line Check

    public bool CheckGameOverLine()
    {
        return CheckIsLineOccupied(20);
    }

    public int OnCheckLines(int customStartLine = 0)
    {
        for(int y = customStartLine; y < gridYSize; y++)
        {
            if (CheckIsLineFull(y))
            {
                return y;
            }
        }

        return -1;
    }

    public void DeleteLine(int y)
    {
        for (int x = 0; x < gridXSize; x++)
        {
            Vector2 deletePoint = new Vector2(x, y);
            TetriminoBlock targetToDelete = m_gridLayout[deletePoint];

            m_gridLayout[deletePoint] = null;
            targetToDelete.OnBlockDeleted();
        }

        MoveDownTetriminosDone(y + 1);
        AudioManager.Instance.PlayLineCleared();
    }

    private void MoveDownTetriminosDone(int startY)
    {
        List<Vector2> previousPosList = new List<Vector2>();
        Dictionary<Vector2, TetriminoBlock> newPosList = new Dictionary<Vector2, TetriminoBlock>();

        for (int x = 0; x < gridXSize; x++)
        {
            for(int y = startY; y < gridYSize; y++)
            {
                Vector2 deletePoint = new Vector2(x, y);

                if (m_gridLayout[deletePoint] == null)
                    continue;

                previousPosList.Add(m_gridLayout[deletePoint].GridPosition);

                m_gridLayout[deletePoint].GridPosition += Vector2.down;
                newPosList.Add(m_gridLayout[deletePoint].GridPosition, m_gridLayout[deletePoint]);
                m_gridLayout[deletePoint].OnForceMoveDown();
            }            
        }

        foreach(Vector2 previousPos in previousPosList)
        {
            m_gridLayout[previousPos] = null;
        }

        foreach (Vector2 newPos in newPosList.Keys)
        {
            m_gridLayout[newPos] = newPosList[newPos];
        }
    }

    // Returns True if all line is occupied by a block
    private bool CheckIsLineFull(int y)
    {
        bool full = true;

        for(int x = 0; x < gridXSize; x++)
        {
            Vector2 testPoint = new Vector2(x, y);
            
            if (m_gridLayout[testPoint] == null)
            {
                full = false;
                break;
            }            
        }

        return full;
    }

    // Returns True if line is occupied by at least one block
    private bool CheckIsLineOccupied(int y)
    {
        bool occupied = false;

        for (int x = 0; x < gridXSize; x++)
        {
            Vector2 testPoint = new Vector2(x, y);

            if (m_gridLayout[testPoint] != null)
            {
                occupied = true;
                break;
            }
        }

        return occupied;
    }

    #endregion

    #region Gizmos 

    private void OnDrawGizmos()
    {
        foreach(Vector2 point in m_gridLayout.Keys)
        {
            if (m_gridLayout[point] != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(gridGizmosModifier + (Vector3)point, 0.3f);
            }
            else
            {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(gridGizmosModifier + (Vector3)point, 0.3f);
            }
        }
    }

    #endregion
}
