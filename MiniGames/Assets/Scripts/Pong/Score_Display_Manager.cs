using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;

public class Score_Display_Manager : MonoBehaviour
{

    public TMP_Text LeftTextScore;
    public TMP_Text RightTextScore;
    public TMP_Text FinalTextScore;

    void Start()
    {
        if (FinalTextScore != null)
        {
            UpdateFinalScoreText();
        }   
    }

    public void UpdateLeftScoreText(int leftScore)
    {
        //Debug.Log("Left Scored: " + leftScore);
        LeftTextScore.text = "" + leftScore.ToString();
    }

    public void UpdateRightScoreText(int rightScore)
    {
        //Debug.Log("Right Scored: " + rightScore);
        RightTextScore.text = "" + rightScore.ToString();
    }

    public void UpdateFinalScoreText()
    {
        int leftScore = PlayerPrefs.GetInt("PongLeftScore", 0);
        int rightScore = PlayerPrefs.GetInt("PongRightScore", 0);
        FinalTextScore.text = "Left: " + leftScore.ToString() + "  Right: " + rightScore.ToString();
    }

}
