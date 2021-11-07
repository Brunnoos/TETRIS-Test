using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int m_currentScore = 0;

    private bool m_isOn = false;

    public bool IsOn { get => m_isOn; set => m_isOn = value; }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = m_currentScore.ToString();
    }

    public void AddScore(int value)
    {
        m_currentScore += value;
    }

    public void ResetScore()
    {
        m_currentScore = 0;
    }
}
