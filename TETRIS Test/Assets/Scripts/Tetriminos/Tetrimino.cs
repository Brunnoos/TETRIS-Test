using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetrimino : MonoBehaviour
{
    private enum PivotPosition { OnGridLine, InsideGrid }

    [SerializeField] private Transform rotationPivot;
    [SerializeField] private PivotPosition pivotPosition;
    [SerializeField] private List<TetriminoBlock> blocks;

    private List<TetriminoBlock> m_blocksToRaycast = new List<TetriminoBlock>();

    private bool m_canMoveDown = true;
    private bool m_canMoveLeft = true;
    private bool m_canMoveRight = true;

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
            block.OnSetup(this, blockColliders);
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
        m_canMoveDown = false;

        if (!_isDone)
        {
            _isDone = true;
            GameManager.Instance.OnChooseTetriminoToSpawn();
        }
    }

    #endregion

    #region Movement

    public void OnAutoMoveDown()
    {
        if (m_canMoveDown)
        {
            transform.position -= new Vector3(0, 1);
        }        
    }

    public void OnMoveUp()
    {
        transform.position += new Vector3(0, 2);
    }

    public void OnRotate(bool clockwise)
    {
        rotationPivot.Rotate(new Vector3(0, 0, (clockwise) ? -90 : 90));

        foreach(TetriminoBlock block in blocks)
        {
            block.OnRotateCheck();
        }
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
