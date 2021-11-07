using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTetrimino : MonoBehaviour
{
    [SerializeField] private List<GhostBlock> ghostBlocks;
    [SerializeField] private Vector3 ghostPosModifier;

    private Tetrimino m_targetTetrimino = null;
    private List<TetriminoBlock> m_targetBlocks = new List<TetriminoBlock>();
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupGhostTarget(Tetrimino target, List<TetriminoBlock> blocks)
    {
        m_targetTetrimino = target;
        m_targetBlocks = blocks;
    }

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
            if (!block.TryMove(direction, m_targetBlocks))
            {
                success = false;
                break;
            }
        }

        return success;
    }

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
}
