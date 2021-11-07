using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public struct BlockPosition
{
    public List<Vector2> relativeIndexes;
}

public class TetriminoBlock : MonoBehaviour
{
    #region Inspector

    [SerializeField] private bool isPivot = false;
    [SerializeField] private List<Vector2> relativeIndexes;

    #endregion

    #region Internal

    // For All Blocks
    private Tetrimino m_parent;
    private Vector2 m_gridPosition;
    private Vector2 m_previousGridPosition;
    private TetriminoBlock m_pivotBlock = null;

    // Pivot Blocks only
    private Vector3 m_pivotNorthPosition;
    private Vector2 m_pivotNorthGridPosition;

    // Temp Pivot
    private Vector2 m_tempGridPosition;

    #endregion

    #region Sets & Gets

    public bool GetIsPivot { get => isPivot; }

    public List<Vector2> GetRelativePositions { get => relativeIndexes; }

    public Vector2 GridPosition { get => m_gridPosition; set => m_gridPosition = value; }
    public Vector2 PreviousGridPosition { get => m_previousGridPosition; }

    public Vector2 GetTempGridPosition { get => m_tempGridPosition; }

    #endregion

    #region Setup

    public void OnSetup(Vector2 pivotGridStartPosition, TetriminoBlock pivot, Tetrimino parent)
    {
        m_gridPosition = pivotGridStartPosition + relativeIndexes[0];
        m_previousGridPosition = m_gridPosition;
        m_pivotBlock = pivot;
        m_parent = parent;
    }

    // Pivot Setup is different to keep its north position and grid point intact, as it's used for reference when rotating
    public void OnPivotSetup(Vector2 gridStartPosition, Tetrimino parent)
    {
        m_pivotNorthPosition = transform.position;
        m_pivotNorthGridPosition = gridStartPosition;
        m_gridPosition = m_pivotNorthGridPosition;
        m_previousGridPosition = m_gridPosition;
        m_parent = parent;
    }

    #endregion

    #region Movement

    // Rotates the block around its pivot (if its not a pivot)
    public void OnRotate(int direction)
    {        
        m_previousGridPosition = m_gridPosition;

        if (!isPivot && m_pivotBlock != null)
        {
            transform.position = m_pivotBlock.transform.position + (Vector3)relativeIndexes[direction];
            m_gridPosition = m_pivotBlock.GridPosition + relativeIndexes[direction];
        }
        else if (isPivot)
        {
            transform.position = m_pivotNorthPosition + (Vector3)relativeIndexes[direction];
            m_gridPosition = m_pivotNorthGridPosition + relativeIndexes[direction];
        }
    }

    // Returns the Grid Position for the desired rotation
    public Vector2 OnTestRotation(int direction, Vector2 pivotTempPosition)
    {
        Vector2 tempPosition = m_gridPosition;

        if (!isPivot && m_pivotBlock != null)
        {
            tempPosition = pivotTempPosition + relativeIndexes[direction];
        }
        else if (isPivot)
        {
            tempPosition = m_pivotNorthGridPosition + relativeIndexes[direction];
        }

        return tempPosition;
    }

    // Moves the piece
    public void OnMove(Vector2 direction)
    {
        m_previousGridPosition = m_gridPosition;

        if (!isPivot)
        {
            m_gridPosition += direction;
        }
        else
        {
            m_pivotNorthPosition += (Vector3)direction;
            m_pivotNorthGridPosition += direction;
            m_gridPosition += direction;
        }
    }

    // Returns the Grid Position for the desired move
    public Vector2 OnTestMove(Vector2 direction, bool useTemp = false)
    {
        Vector2 tempPosition = (!useTemp) ? m_gridPosition : m_tempGridPosition;

        tempPosition += direction;        

        return tempPosition;
    }

    public void OnForceMoveDown()
    {
        transform.position += Vector3.down;
    }

    #endregion

    #region Collision Handle

    public bool TryRotate(int direction, List<TetriminoBlock> ignoredBlocks)
    {
        Vector2 tempGridPosition;

        if (!isPivot && m_pivotBlock != null)
        {
            Vector2 tempPivotGridPosition = m_pivotBlock.OnTestRotation(direction, Vector2.zero);

            tempGridPosition = OnTestRotation(direction, tempPivotGridPosition);

            m_tempGridPosition = tempGridPosition;

            return GameManager.Instance.GetPlayfield.CheckGridSlotFree(tempGridPosition, ignoredBlocks);
        }
        else if (isPivot)
        {
            tempGridPosition = m_pivotNorthGridPosition + relativeIndexes[direction];

            m_tempGridPosition = tempGridPosition;

            return GameManager.Instance.GetPlayfield.CheckGridSlotFree(tempGridPosition, ignoredBlocks);
        }

        return false;
    }

    public bool TryMove(Vector2 direction, List<TetriminoBlock> ignoredBlocks, bool keepTemp = false)
    {
        Vector2 tempGridPosition = OnTestMove(direction);

        // This prevents a Move Test from erasing previous data,
        // useful when trying to move for a desired rotation (keeps the rotation position for all tests)
        if (!keepTemp)
            m_tempGridPosition = tempGridPosition; 

        return GameManager.Instance.GetPlayfield.CheckGridSlotFree(tempGridPosition, ignoredBlocks);
    }

    #endregion

    #region Delete Block

    public void OnBlockDeleted()
    {
        m_parent.OnBlockDeleted(this);

        Destroy(gameObject);
    }

    #endregion

    private void OnDrawGizmos()
    {
        Handles.color = Color.magenta;
        Handles.Label(transform.position, m_gridPosition.ToString());
    }
}
