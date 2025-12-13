using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score_Display_Manager : MonoBehaviour
{
    int leftScore = 0;
    int rightScore = 0;

    public TMP_Text LeftTextScore;
    public TMP_Text RightTextScore;


    public void LeftScored()
    {
        leftScore++;
        //Debug.Log("Left Scored: " + leftScore);
        LeftTextScore.text = "" + leftScore.ToString();
    }

    public void RightScored()
    {
        rightScore++;
        //Debug.Log("Right Scored: " + rightScore);
        RightTextScore.text = "" + rightScore.ToString();
    }

}
