using UnityEngine;

public class Score_Manager : MonoBehaviour
{
    int score = 0;
    int scoreType = 0; // 0: Infinite, 1: Tennis, 2: Football
    int MAX_SCORE = 0; // if 0 then infinite
    int timelimit = 0; // 0 if no time limit
    
    void Start()
    {
        // check the selected pong mode to set scoring type
        scoreType = (int)DontDestroyMe.PongMode;

        switch (scoreType)
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
