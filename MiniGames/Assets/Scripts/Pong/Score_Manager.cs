using UnityEngine;
using UnityEngine.SceneManagement;

public class Score_Manager : MonoBehaviour
{
    int leftScore = 0;
    int rightScore = 0;

    int GameMode = 0; // 0: Infinite, 1: ScoreLimit, 2: Countdown
    int MAX_SCORE = 0; // if 0 then infinite
    int timelimit = 0; // 0 if no time limit

    public Ball_Controller ball;
    public Score_Display_Manager scoreDisplay;
    public TimerScript timer;
    public GameObject timerTextObject;
    public GameObject TimerBackgroundObject;

    AudioSource Aud_score;
    
    void Start()
    {
        // check the selected pong mode to set scoring type
        GameMode = (int)DontDestroyMe.PongMode;

        switch (GameMode)
        {
            case 0: // Infinite Pong
                Debug.Log("Infinite Pong Mode Selected");
                setInfinitePong();
                break;
            case 1: // ScoreLimit Pong
                Debug.Log("ScoreLimit Pong Mode Selected");
                setScoreLimitPong();
                break;
            case 2: // Countdown Pong
                Debug.Log("Countdown Pong Mode Selected");
                setCountdownPong();
                break;
            default:
                Debug.Log("Unknown Pong Mode Selected");
                break;
        }

        Aud_score = GetComponent<AudioSource>();
        timerTextObject.SetActive(GameMode == 2); // only show timer for countdown Pong
        TimerBackgroundObject.SetActive(GameMode == 2); // only show timer background for countdown Pong
    }

    void Update()
    {
        checkForScore();

        if (GameMode != 0)  // only enter if not Infinite Pong
            checkForGameEnd();
    }

    void SaveScores()
    {
        PlayerPrefs.SetInt("PongLeftScore", leftScore);
        PlayerPrefs.SetInt("PongRightScore", rightScore);
        PlayerPrefs.Save();
        Debug.Log("Scores saved: Left=" + leftScore + " Right=" + rightScore);
    }

    void checkForScore()
    {
       if (ball == null)
            return;
        
        Vector3 screenPos = Camera.main.WorldToScreenPoint(ball.transform.position);

        if(screenPos.x < 0)
        {
            rightScore++;
            Aud_score.Play(0);
            ball.resetBall();
            scoreDisplay.UpdateRightScoreText(rightScore);
        }

        else if(screenPos.x > Screen.width)
        {
            leftScore++;
            Aud_score.Play(0);
            ball.resetBall();
            scoreDisplay.UpdateLeftScoreText(leftScore);
        }
    }

    void checkForGameEnd()
    {
        // !! ScoreLimit !!
        if (GameMode == 1)
        {
            if (MAX_SCORE > 0)
            {
                if (leftScore >= MAX_SCORE || rightScore >= MAX_SCORE)
                {
                    // End the game
                    SaveScores();
                    SceneManager.LoadScene("Pong Game Over Screen");
                    // Implement end game logic here (e.g., load end screen, display winner, etc.)
                }
            }
        }
        // !! Countdown !!
        else if (GameMode == 2)
        {
            if (timelimit <= 0)
            {
                // end game 
                SaveScores();
                SceneManager.LoadScene("Pong Game Over Screen");
                Debug.Log("Game Over! Final Score - Left: " + leftScore + " Right: " + rightScore);
            }
            // Countdown Pong time limit logic would go here
            // This is a placeholder as time tracking is not implemented in this snippet
        }
    }

    void setInfinitePong()
    {
        // Infinite Pong mode logic
        // rules: endless play, no end screen
        MAX_SCORE = 0;
        timelimit = 0;
    }

    void setScoreLimitPong()
    {
        // ScoreLimit Pong mode logic
        // rules: first to 11 points wins
        MAX_SCORE = 3;
        timelimit = 0;
    }

    void setCountdownPong()
    {
        // Countdown Pong mode logic
        // rules: two halves, most goals wins
        MAX_SCORE = 0; // score limit not used in Countdown Pong, time limit based
        timelimit = 100; // 2 halves of 2 minutes each = 4 minutes total
        timer.StartTimer(timelimit);
    }

}
