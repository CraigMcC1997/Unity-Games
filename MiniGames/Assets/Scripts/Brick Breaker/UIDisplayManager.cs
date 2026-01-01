using UnityEngine;
using TMPro;

public class UIDisplayManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text roundText;

    public void UpdateScoreText(int score, int maxScore)
    {
        scoreText.text = "Score: " + score + " / " + maxScore;
    }

    public void UpdateLivesText(int lives)
    {
        livesText.text = lives.ToString();
    }

    public void UpdateRoundText(int round)
    {
        roundText.text = "Round: " + round;
    }
}
