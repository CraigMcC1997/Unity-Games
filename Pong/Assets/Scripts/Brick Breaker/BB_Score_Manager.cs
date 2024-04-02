using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BB_Score_Manager : MonoBehaviour
{
    int Score = 0;
    int lives = 3;

    public TMP_Text TextScore;
    public TMP_Text TextLives;

    public void Scored()
    {
        Score++;
        Debug.Log("Score: " + Score);
        TextScore.text = "" + Score.ToString();
    }

    public void Died()
    {
        lives--;
        Debug.Log("Died");
        TextLives.text = "" + lives.ToString();
    }
}
