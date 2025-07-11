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

    public TMP_Text TextScore;
    public TMP_Text TextLives;

    public GameObject Brick_Spawner;

    public void Start()
    {
        if (Brick_Spawner == null)
        {
            Debug.LogError("Brick_Spawner is not assigned in the BB_Score_Manager script.");
            return;
        }
        if (Brick_Spawner.GetComponent<Brick_Spawner>() == null)
        {
            Debug.LogError("Brick_Spawner does not have a Brick_Spawner component.");
            return;
        }

        MAX_SCORE = Brick_Spawner.GetComponent<Brick_Spawner>().MAX_SCORE;
        Debug.Log("Max Score: " + MAX_SCORE);
    }

    public void Scored()
    {
        Score++;
        Debug.Log("Score: " + Score);
        TextScore.text = "" + Score.ToString();

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
            TextLives.text = "" + lives.ToString();
        }
    }
}
