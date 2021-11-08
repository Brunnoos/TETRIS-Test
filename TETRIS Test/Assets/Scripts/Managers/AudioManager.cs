using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    #region Singleton

    private static AudioManager _instance = null;

    public static AudioManager Instance { get => _instance; }

    #endregion

    #region Inspector

    [Header("Game Flow")]
    [SerializeField] private AudioClip onLineCleared;
    [SerializeField] private AudioClip onTetriminoDone;
    [SerializeField] private AudioClip onGameOver;
    [SerializeField] private AudioClip onGameStarted;

    [Header("UI")]
    [SerializeField] private AudioClip onMenuFlow;
    [SerializeField] private AudioClip onMenuButtonPressed;

    #endregion

    #region Internal

    private AudioSource m_source;

    #endregion

    #region UNITY

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
    }

    // Start is called before the first frame update
    void Start()
    {
        m_source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region Audio Comands

    public void PlayLineCleared()
    {
        m_source.clip = onLineCleared;
        m_source.Play();
    }

    public void PlayTetriminoDone()
    {
        m_source.clip = onTetriminoDone;
        m_source.Play();
    }

    public void PlayGameOver()
    {
        m_source.clip = onGameOver;
        m_source.Play();
    }

    public void PlayMenuFlow()
    {
        m_source.clip = onMenuFlow;
        m_source.Play();
    }
    public void PlayMenuButtonPressed()
    {
        m_source.clip = onMenuButtonPressed;
        m_source.Play();
    }

    #endregion
}
