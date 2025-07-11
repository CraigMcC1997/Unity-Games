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
        MAX_SCORE = Brick_Spawner.GetComponent<Brick_Spawner>().MAX_SCORE;
    }

    public void Scored()
    {
        Score++;

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
