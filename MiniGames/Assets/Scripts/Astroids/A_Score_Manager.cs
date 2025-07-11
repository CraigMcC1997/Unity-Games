using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class A_Score_Manager : MonoBehaviour
{
    int Score = 0;
    int lives = 3;

    public TMP_Text TextScore;
    public TMP_Text TextLives;

    public void Destroyed_Asteroid()
    {
        Score++;
        //Debug.Log("Score: " + Score);
        TextScore.text = "" + Score.ToString();
    }

    public void Hit_Ship()
    {
        lives--;
        //Debug.Log("Hit!");
        TextLives.text = "" + lives.ToString();
    }
}
