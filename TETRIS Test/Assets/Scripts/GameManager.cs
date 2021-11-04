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
    [SerializeField] private GridChecker leftBorderChecker;

    #endregion

    #region Internal

    private PlayerControls controller;

    private float m_timer = 0;
    private float m_tetriminoStepDelay = 0.5f; // Default value

    private Tetrimino m_currentTetrimino = null;

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

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;

        if (m_timer >= m_tetriminoStepDelay)
        {
            m_timer = 0;

            if (m_currentTetrimino != null)
                m_currentTetrimino.OnAutoMoveDown();

            leftBorderChecker.CheckLines();
        }
    }

    #region GameFlow

    public void OnStartGame()
    {
        OnChooseTetriminoToSpawn();
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
        controller.Tetrimino.SoftDrop.performed += ctx => SoftDrop();
        controller.Tetrimino.HardDrop.performed += ctx => HardDrop();
    }

    public void RotateTetriminoClockwise()
    {
        if (m_currentTetrimino != null)
            m_currentTetrimino.OnRotate(true);
    }

    public void MoveLeft()
    {
        if (m_currentTetrimino != null)
            m_currentTetrimino.OnMoveLeft();
    }

    public void MoveRight()
    {
        if (m_currentTetrimino != null)
            m_currentTetrimino.OnMoveRight();
    }

    public void SoftDrop()
    {

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
