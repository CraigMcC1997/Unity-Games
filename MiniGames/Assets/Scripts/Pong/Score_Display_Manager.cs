using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score_Display_Manager : MonoBehaviour
{

    public TMP_Text LeftTextScore;
    public TMP_Text RightTextScore;


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

}
