using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SI_Score_Manager : MonoBehaviour
{
    int Score = 0;
    int lives = 3;

    public TMP_Text TextScore;
    public TMP_Text TextLives;

    public void Killed_Invader()
    {
        Score++;
        Debug.Log("Score: " + Score);
        TextScore.text = "" + Score.ToString();
    }

    public void Hit_Paddle()
    {
        lives--;
        Debug.Log("Hit!");
        TextLives.text = "" + lives.ToString();
    }
}
