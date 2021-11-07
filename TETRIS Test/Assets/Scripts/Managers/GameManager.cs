using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public enum GameState { Menu, GameFlow, GameOver }

public class GameManager : MonoBehaviour
{

    #region Singleton

    private static GameManager _instance = null;

    public static GameManager Instance { get => _instance; }

    #endregion

    #region Inspector

    [Header("Game Flow")]
    [SerializeField] private GameFlow gameFlow;

    [Space(5)]
    [SerializeField] private GameObject gameFlowUI;
    [SerializeField] private GameObject gameFlowButtons;
    [SerializeField] private List<UIElement> gameFlowUIElements;

    [Header("Menu")]
    [SerializeField] private GameObject menuUI;
    [SerializeField] private List<UIElement> menuUIElements;
    [SerializeField] private GameObject continueButton;

    [Header("Game Over")]
    [SerializeField] private GameObject gameOverButtons;
    [SerializeField] private List<UIElement> gameOverUIElements;

    #endregion

    #region Internal

    private GameState m_currentState = GameState.Menu;

    private PlayerControls m_controller;

    // UI 
    private int m_uiIndex = -1;
    private List<UIElement> m_targetUI;

    #endregion

    #region Sets & Gets

    public PlayerControls GetController { get => m_controller; }

    public GameState GetCurrentState { get => m_currentState; }

    #endregion

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        Screen.SetResolution(1920, 1080, true);

        SetupControls();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetCurrentUI(m_currentState);
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine(); 
    }

    private void StateMachine()
    {
        switch(m_currentState)
        {
            case GameState.Menu:

                break;

            case GameState.GameFlow:

                if (!gameFlow.GetGameStarted)
                    gameFlow.OnStartGame();
                else if (!gameFlow.GetIsOn)
                    gameFlow.OnResumeGame();

                break;
        }
    }

    public void SwitchState(GameState newState)
    {
        if (newState != m_currentState)
        {
            m_currentState = newState;
            SetCurrentUI(m_currentState);
        }
    }

    #region UI

    private void SetCurrentUI(GameState state)
    {
        switch(state)
        {
            case GameState.Menu:
                gameFlowUI.SetActive(false);
                
                menuUI.SetActive(true);
                m_targetUI = menuUIElements;

                if (gameFlow.GetGameStarted)
                {
                    continueButton.SetActive(true);
                    m_targetUI.Insert(0, continueButton.GetComponent<UIElement>());
                }
                else
                {
                    continueButton.SetActive(false);
                }

                break;

            case GameState.GameFlow:
                menuUI.SetActive(false);

                gameFlowUI.SetActive(true);
                gameFlowButtons.SetActive(true);
                gameOverButtons.SetActive(false);

                m_targetUI = gameFlowUIElements;

                break;

            case GameState.GameOver:
                menuUI.SetActive(false);

                gameFlowUI.SetActive(true);
                gameFlowButtons.SetActive(false);
                gameOverButtons.SetActive(true);

                m_targetUI = gameFlowUIElements;

                break;
        }

        m_uiIndex = -1;
    }

    private void SetupControls()
    {
        m_controller = new PlayerControls();

        m_controller.UI.MoveUp.performed += ctx => MoveUpUI();
        m_controller.UI.MoveDown.performed += ctx => MoveDownUI();
        m_controller.UI.Confirm.performed += ctx => ConfirmButton();
        m_controller.UI.Exit.performed += ctx => ExitButton();
    }

    private void MoveUpUI()
    {
        if (m_currentState != GameState.GameFlow && m_uiIndex >= -1)
        {
            if (m_uiIndex > 0)
            {
                m_targetUI[m_uiIndex].UnhighlightElement();
                m_uiIndex--;
            }
            else
            {
                m_uiIndex = 0;
            }               
            m_targetUI[m_uiIndex].HighlightElement();
        }            
    }

    private void MoveDownUI()
    {
        if (m_currentState != GameState.GameFlow && m_uiIndex < m_targetUI.Count - 1)
        {
            if (m_uiIndex >= 0)
                m_targetUI[m_uiIndex].UnhighlightElement();

            m_uiIndex++;
            m_targetUI[m_uiIndex].HighlightElement();
        }            
    }

    private void ConfirmButton()
    {
        if (m_currentState != GameState.GameFlow)
            m_targetUI[m_uiIndex].OnConfirm();
    }

    private void ExitButton()
    {
        if (m_currentState == GameState.GameFlow)
        {
            gameFlow.OnPauseGame();
        }
        else
        {
            if (gameFlow.GetGameStarted)
                SwitchState(GameState.GameFlow);
        }
    }

    #endregion

    #region UI Actions

    public void StartGame()
    {
        SwitchState(GameState.GameFlow);
    }

    public void ContinueGame()
    {
        SwitchState(GameState.GameFlow);
    }

    public void PauseGame()
    {
        SwitchState(GameState.Menu);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    #endregion

    private void OnEnable()
    {
        m_controller.Enable();
    }

    private void OnDisable()
    {
        m_controller.Disable();
    }
}
