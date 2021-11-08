using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    #region Inspector

    [SerializeField] private TextMeshProUGUI scoreText;

    #endregion

    #region Internal

    private int m_currentScore = 0;

    #endregion

    #region UNITY

    // Update is called once per frame
    void Update()
    {
        scoreText.text = m_currentScore.ToString();
    }

    #endregion

    #region Score Management

    public void AddScore(int value)
    {
        m_currentScore += value;
    }

    public void ResetScore()
    {
        m_currentScore = 0;
    }

    #endregion
}
