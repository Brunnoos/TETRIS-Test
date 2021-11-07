using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameFlow : MonoBehaviour
{
    #region Singleton

    private static GameFlow _instance = null;

    public static GameFlow Instance { get => _instance; }

    #endregion

    #region Inspector

    [Header("Tetrimino Settings")]
    [SerializeField] private List<GameObject> prefabTetriminos;
    [SerializeField] private Transform tetriminosHolder;

    [Header("Playfield")]
    [SerializeField] private Playfield playfield;

    [Header("Score Manager")]
    [SerializeField] private ScoreManager scoreManager;

    [Header("Tetrimino Queue")]
    [SerializeField] private Transform queueHolder;
    [SerializeField] private Transform nextTetriminoPoint;
    [SerializeField] private List<Transform> queuePoints;
    [SerializeField] private Vector3 queueScale;

    [Header("Ghost")]
    [SerializeField] private GhostTetrimino ghostTetrimino;

    #endregion

    #region Internal

    private bool m_isOn = false;
    private bool m_gameStarted = false;

    private float m_timer = 0;
    private float m_tetriminoStepDelay = 1f; // Default value
    private float m_timerSpeed = 1f;
    private bool m_hardDrop = false;

    private Tetrimino m_currentTetrimino = null;
    private bool m_canSpawn = false;
    private Tetrimino m_nextTetrimino = null;
    private List<Tetrimino> m_blocksInQueue = new List<Tetrimino>(4);

    #endregion

    #region Sets & Gets

    public Playfield GetPlayfield { get => playfield; }

    public bool GetIsOn { get => m_isOn; }
    public bool GetGameStarted { get => m_gameStarted; }

    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        SetupControls();
    }

    private void Update()
    {
        if (m_canSpawn && m_isOn)
        {
            m_hardDrop = false;
            UpdateTetriminoQueue();
            m_canSpawn = false;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (m_isOn)
        {
            m_timer += Time.deltaTime * m_timerSpeed;

            if (m_timer >= m_tetriminoStepDelay || m_hardDrop)
            {
                m_timer = 0;

                if (m_currentTetrimino != null)
                    m_currentTetrimino.Move(Vector2.down);
            }
        }       
    }

    #region GameFlow

    public void OnStartGame()
    {
        SetupFirstTetriminoQueue();
        UpdateTetriminoQueue();
        m_isOn = true;
        m_gameStarted = true;

        scoreManager.ResetScore();
    }    

    public void OnTetriminoDone()
    {
        HideGhost();

        if (playfield.CheckGameOverLine())
        {
            // GAME OVER
            OnGameOver();
        }
        else
        {
            OnCheckPlayfieldLines();
        }        
    }

    public void OnCheckPlayfieldLines()
    {
        int lineToDelete = playfield.OnCheckLines();
        if (lineToDelete == -1)
        {
            m_canSpawn = true;
        }
        else
        {
            playfield.DeleteLine(lineToDelete);
            scoreManager.AddScore(100);
            OnCheckPlayfieldLines();
        }
    }

    private void SetupFirstTetriminoQueue()
    {
        // First, setup Next Tetrimino
        m_nextTetrimino = OnChooseTetriminoToSpawn(-1);

        // Second, setup Queue Line until the last position
        for(int i = 0; i < 6; i++)
        {
            OnChooseTetriminoToSpawn(i);
        }
    }

    private void UpdateTetriminoQueue()
    {
        // First, move next Tetrimino to Playfield
        OnMoveNextTetriminoToPlayfield();

        // Second, move first tetrimino in queue to Next Tetrimino position
        OnUpdateNextTetrimino();

        // Third, update queue line
        OnUpdateQueuePositions();

        // Last, spawn new tetrimino to the end of the line
        OnChooseTetriminoToSpawn(5);
    }

    public Tetrimino OnChooseTetriminoToSpawn(int queuePosition)
    {
        int randomNumber = Random.Range(0, prefabTetriminos.Count);

        return OnSpawnTetrimino(prefabTetriminos[randomNumber], queuePosition);
    }

    public Tetrimino OnSpawnTetrimino(GameObject tetrimino, int queuePosition)
    {
        if (tetrimino != null)
        {
            GameObject newTetriminoObj = Instantiate(tetrimino, queueHolder);
            Tetrimino newTetrimino = newTetriminoObj.GetComponent<Tetrimino>();

            if (queuePosition == -1)
            {
                m_nextTetrimino = newTetrimino;
                newTetrimino.Initialize(nextTetriminoPoint.position);
            }
            else
            {
                m_blocksInQueue.Add(newTetrimino);
                newTetrimino.Initialize(queuePoints[queuePosition].position);
                newTetrimino.OnScalePiece(queueScale);
            }            

            return newTetrimino;
        }

        return null;
    }

    private void OnMoveNextTetriminoToPlayfield()
    {
        m_nextTetrimino.transform.SetParent(tetriminosHolder);

        if (playfield.CheckTetriminoSpawnPoints(m_nextTetrimino.GetAllBlocks))
        {
            m_currentTetrimino = m_nextTetrimino;
            m_currentTetrimino.OnMovePiece(playfield.SpawnPoint.position, false);
            m_currentTetrimino.OnUpdatePivotPosition();
            m_currentTetrimino.OnUpdatePlayfield();
            SetupGhost();
        }
        else
        {
            // Can't Spawn -> Game Over
            m_currentTetrimino = null;
            OnGameOver();
        }
    }

    private void OnUpdateNextTetrimino()
    {
        m_nextTetrimino = m_blocksInQueue[0];

        m_nextTetrimino.OnMovePiece(nextTetriminoPoint.position, true);
        m_nextTetrimino.OnScalePiece(Vector3.one);
        m_blocksInQueue.Remove(m_nextTetrimino);
    }

    private void OnUpdateQueuePositions()
    {
        for (int i = 0; i < m_blocksInQueue.Count; i++)
        {
            m_blocksInQueue[i].OnMovePiece(queuePoints[i].position, true);
        }
    } 

    private void OnGameOver()
    {
        m_isOn = false;
        GameManager.Instance.SwitchState(GameState.GameOver);
    }

    #endregion

    #region Controls

    public void SetupControls()
    {
        PlayerControls controller = GameManager.Instance.GetController;
        controller.Tetrimino.RotateClockwise.performed += ctx => RotateTetriminoClockwise();

        controller.Tetrimino.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        controller.Tetrimino.Move.canceled += ctx => Move(Vector2.zero);

        controller.Tetrimino.SoftDrop.performed += ctx => SoftDrop(false);
        controller.Tetrimino.SoftDrop.canceled += ctx => SoftDrop(true);

        controller.Tetrimino.HardDrop.performed += ctx => HardDrop();

        controller.Tetrimino.Pause.performed += ctx => OnPauseGame();
    }

    public void RotateTetriminoClockwise()
    {
        if (m_isOn && m_currentTetrimino != null)
            m_currentTetrimino.ChangeDirection();
    }

    public void Move(Vector2 direction)
    {
        if (m_isOn && m_currentTetrimino != null)
            m_currentTetrimino.ChangeMovement(direction);
    }

    public void SoftDrop(bool stop)
    {
        if (m_isOn)
        {
            if (!stop)
            {
                m_timerSpeed = 20f;
            }
            else
            {
                m_timerSpeed = 1f;
            }
        }        
    }

    public void HardDrop()
    {
        if (m_isOn)
            m_hardDrop = true;  
    }

    public void OnResumeGame()
    {
        GameManager.Instance.SwitchState(GameState.GameFlow);
        m_isOn = true;
    }

    public void OnPauseGame()
    {
        if (m_isOn && GameManager.Instance.GetCurrentState == GameState.GameFlow)
        {
            GameManager.Instance.SwitchState(GameState.Menu);
            m_isOn = false;
        }       
    }

    #endregion

    #region End Game

    public void OnEndGame()
    {
        m_gameStarted = false;
        m_isOn = false;
        GameManager.Instance.SwitchState(GameState.Menu);

        ResetVariables();
    }

    private void ResetVariables()
    {
        playfield.ResetPlayfield();
        scoreManager.ResetScore();
        m_timer = 0;
        m_timerSpeed = 1f;
        m_hardDrop = false;

        m_currentTetrimino = null;
        m_canSpawn = false;
        m_nextTetrimino = null;

        Tetrimino[] allTetriminos = FindObjectsOfType<Tetrimino>();
        for (int i = 0; i < allTetriminos.Length; i++)
        {
            Destroy(allTetriminos[i].gameObject);
        }
        m_blocksInQueue = new List<Tetrimino>();
    }

    #endregion

    #region Ghost Controller

    public void SetupGhost()
    {
        ghostTetrimino.SetupGhostTarget(m_currentTetrimino, m_currentTetrimino.GetAllBlocks);
        ShowGhost();
        OnUpdateGhost();
    }

    public void OnUpdateGhost()
    {
        ghostTetrimino.UpdateGhost();
    }
    public void ShowGhost()
    {
        ghostTetrimino.ShowGhost();
    }
    public void HideGhost()
    {
        ghostTetrimino.HideGhost();
    }

    #endregion
}
