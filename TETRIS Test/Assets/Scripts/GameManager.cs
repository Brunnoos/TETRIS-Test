using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager _instance = null;

    public static GameManager Instance { get => _instance; }

    #endregion

    #region Inspector

    [Header("Tetrimino Settings")]
    [SerializeField] private List<GameObject> prefabTetriminos;
    [SerializeField] private Transform tetriminosHolder;

    [Header("Playfield")]
    [SerializeField] private Playfield playfield;

    #endregion

    #region Internal

    private PlayerControls controller;

    private float m_timer = 0;
    private float m_tetriminoStepDelay = 1f; // Default value
    private float m_timerSpeed = 1f;

    private Tetrimino m_currentTetrimino = null;
    private bool m_canSpawn = false;

    #endregion

    #region Sets & Gets

    public Playfield GetPlayfield { get => playfield; }

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

        SetupControls();
    }

    private void Start()
    {
        OnStartGame();
    }

    private void Update()
    {
        if (m_canSpawn)
        {
            OnChooseTetriminoToSpawn();
            m_canSpawn = false;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        m_timer += Time.deltaTime * m_timerSpeed;

        if (m_timer >= m_tetriminoStepDelay)
        {
            m_timer = 0;

            if (m_currentTetrimino != null)
                m_currentTetrimino.Move(Vector2.down);
        }
    }

    #region GameFlow

    public void OnStartGame()
    {
        OnChooseTetriminoToSpawn();
    }

    public void OnTetriminoDone()
    {
        OnCheckPlayfieldLines();
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
            OnCheckPlayfieldLines();
        }
    }

    public void OnChooseTetriminoToSpawn()
    {
        int randomNumber = Random.Range(0, prefabTetriminos.Count);

        OnSpawnTetrimino(prefabTetriminos[randomNumber]);
    }

    public void OnSpawnTetrimino(GameObject tetrimino)
    {
        if (tetrimino != null)
        {
            GameObject newTetrimino = Instantiate(tetrimino, tetriminosHolder);
            m_currentTetrimino = newTetrimino.GetComponent<Tetrimino>();
            m_currentTetrimino.Initialize(playfield.SpawnPoint.position);
        }
    }

    #endregion

    #region Controls

    public void SetupControls()
    {
        controller = new PlayerControls();
        controller.Tetrimino.RotateClockwise.performed += ctx => RotateTetriminoClockwise();

        controller.Tetrimino.MoveLeft.performed += ctx => MoveLeft();
        controller.Tetrimino.MoveRight.performed += ctx => MoveRight();

        controller.Tetrimino.SoftDrop.performed += ctx => SoftDrop(false);
        controller.Tetrimino.SoftDrop.canceled += ctx => SoftDrop(true);

        controller.Tetrimino.HardDrop.performed += ctx => HardDrop();
    }

    public void RotateTetriminoClockwise()
    {
        if (m_currentTetrimino != null)
            m_currentTetrimino.ChangeDirection();
    }

    public void MoveLeft()
    {
        if (m_currentTetrimino != null)
            m_currentTetrimino.Move(Vector2.left);
    }

    public void MoveRight()
    {
        if (m_currentTetrimino != null)
            m_currentTetrimino.Move(Vector2.right);
    }

    public void SoftDrop(bool stop)
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

    public void HardDrop()
    {

    }

    private void OnEnable()
    {
        controller.Enable();
    }

    private void OnDisable()
    {
        controller.Disable();
    }

    #endregion
}
