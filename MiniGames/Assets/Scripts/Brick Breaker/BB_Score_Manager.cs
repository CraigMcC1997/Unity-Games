using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BB_Score_Manager : MonoBehaviour
{
    int MAX_SCORE;
    int currentScore = 0;
    int lives = 3;

    public Brick_Spawner Brick_Spawner;
    public UIDisplayManager uiDisplayManager;

    public void Start()
    {
        MAX_SCORE = Brick_Spawner.GetBrickCount();
        uiDisplayManager.UpdateScoreText(currentScore, MAX_SCORE);
        uiDisplayManager.UpdateLivesText(lives);
    }

    public void Scored()
    {
        currentScore++;
        uiDisplayManager.UpdateScoreText(currentScore, MAX_SCORE);
    }

    public void Died()
    {
        if (lives <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
        else
        {
            lives--;
            uiDisplayManager.UpdateLivesText(lives);
        }
    }

    public int GetMaxScore()
    {
        return MAX_SCORE;
    }

    public int GetScore()
    {
        return currentScore;
    }

    public void ResetStats()
    {
        ResetScore();
        ResetLives();
    }

    void ResetScore()
    {
        currentScore = 0;
        uiDisplayManager.UpdateScoreText(currentScore, MAX_SCORE);
    }

    void ResetLives()
    {
        lives = 3;
        uiDisplayManager.UpdateLivesText(lives);
    }
}
