using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTetrimino : MonoBehaviour
{
    #region Inspector

    [SerializeField] private List<GhostBlock> ghostBlocks;
    [SerializeField] private Vector3 ghostPosModifier;

    #endregion

    #region Internal

    private Tetrimino m_targetTetrimino = null;
    private List<TetriminoBlock> m_targetBlocks = new List<TetriminoBlock>();

    #endregion

    #region Setup

    public void SetupGhostTarget(Tetrimino target, List<TetriminoBlock> blocks)
    {
        m_targetTetrimino = target;
        m_targetBlocks = blocks;
    }

    #endregion Setup

    #region Movement

    public void UpdateGhost()
    {
        BasePosition();
        SendDown();
    }

    private void BasePosition()
    {
        transform.position = m_targetTetrimino.transform.position;

        for(int i = 0; i < m_targetBlocks.Count; i++)
        {
            ghostBlocks[i].transform.position = m_targetBlocks[i].transform.position + ghostPosModifier;
            ghostBlocks[i].GridPosition = m_targetBlocks[i].GridPosition;
        }
    }

    private void SendDown()
    {
        Vector2 finalDistance = Vector2.zero;

        while (TryMove(finalDistance + Vector2.down))
        {
            finalDistance += Vector2.down;
        }

        transform.position += (Vector3)finalDistance + ghostPosModifier;
    }

    private bool TryMove(Vector2 direction)
    {
        bool success = true;

        foreach (TetriminoBlock block in ghostBlocks)
        {
            if (!block.TryMove(direction, m_targetBlocks, false, false))
            {
                success = false;
                break;
            }
        }

        return success;
    }

    #endregion

    #region Show and Hide

    public void ShowGhost()
    {
        foreach(GhostBlock block in ghostBlocks)
        {
            block.Show();
        }
    }

    public void HideGhost()
    {
        foreach (GhostBlock block in ghostBlocks)
        {
            block.Hide();
        }
    }

    #endregion
}
