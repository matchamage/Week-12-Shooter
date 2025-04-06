using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int currentScore = 0;
    public TextMeshProUGUI scoreTextTMPro;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        currentScore += points;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreTextTMPro == null)
        {
            Debug.LogError("Score Text UI element not assigned in the Inspector!");
        }
        else {
            scoreTextTMPro.text = "Score: " + currentScore;
        }
    }
}