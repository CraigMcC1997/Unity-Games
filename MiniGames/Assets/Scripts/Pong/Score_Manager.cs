using UnityEngine;

public class Score_Manager : MonoBehaviour
{
    int leftScore = 0;
    int rightScore = 0;

    int GameMode = 0; // 0: Infinite, 1: Tennis, 2: Football
    int MAX_SCORE = 0; // if 0 then infinite
    int timelimit = 0; // 0 if no time limit

    public Ball_Controller ball;
    public Score_Display_Manager scoreDisplay;

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
            case 1: // Tennis Pong
                Debug.Log("Tennis Pong Mode Selected");
                setTennisPong();
                break;
            case 2: // Football Pong
                Debug.Log("Football Pong Mode Selected");
                setFootballPong();
                break;
            default:
                Debug.Log("Unknown Pong Mode Selected");
                break;
        }

        Aud_score = GetComponent<AudioSource>();
    }

    void Update()
    {
        checkForScore();

        if (GameMode != 0)  // only enter if not Infinite Pong
            checkForGameEnd();
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
        // !! TENNIS !!
        if (GameMode == 1)
        {
            if (MAX_SCORE > 0)
            {
                if (leftScore >= MAX_SCORE || rightScore >= MAX_SCORE)
                {
                    // End the game
                    Debug.Log("Game Over! Final Score - Left: " + leftScore + " Right: " + rightScore);
                    // Implement end game logic here (e.g., load end screen, display winner, etc.)
                }
            }
        }
        // !! FOOTBALL !!
        else if (GameMode == 2)
        {
            // Football Pong time limit logic would go here
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

    void setTennisPong()
    {
        // Tennis Pong mode logic
        // rules: first to 11 points wins
        MAX_SCORE = 11;
        timelimit = 0;
    }

    void setFootballPong()
    {
        // Football Pong mode logic
        // rules: two halves, most goals wins
        MAX_SCORE = 0; // score limit not used in Football Pong, time limit based
        timelimit = 240; // 2 halves of 2 minutes each = 4 minutes total
    }

}
