using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BB_Score_Manager : MonoBehaviour
{
    int MAX_SCORE;
    int Score = 0;
    int lives = 3;


    public Brick_Spawner Brick_Spawner;
    public UIDisplayManager uiDisplayManager;

    public void Start()
    {
        MAX_SCORE = Brick_Spawner.GetMaxScore();
        uiDisplayManager.UpdateScoreText(Score, MAX_SCORE);
        uiDisplayManager.UpdateLivesText(lives);
    }

    public void Scored()
    {
        Score++;
        uiDisplayManager.UpdateScoreText(Score, MAX_SCORE);

        if (Score >= MAX_SCORE)
        {
            SceneManager.LoadScene("Game Win");
            return;
        }
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
}
