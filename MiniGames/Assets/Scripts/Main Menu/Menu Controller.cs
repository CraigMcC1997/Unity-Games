using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // PONG
    public void PlayPong()
    {
        // Load the game scene to chose pong mode
        SceneManager.LoadScene("Pong");
    }

    public void ChosePongMode()
    {
        // Load the pong mode selection scene
        SceneManager.LoadScene("Pong Selection Screen");
    }

    public void InfinitePong()
    {
        // Load the game scene
        //TODO: Add variable to set mode to infinite pong
        // rules: endless play, no end screen
        DontDestroyMe.PongMode = DontDestroyMe.PongModes.InfinitePong;
        PlayPong();
    }

    public void ScoreLimitPong()
    {
        // Load the game scene
        //TODO: Add variable to set mode to ScoreLimit pong
        // rules: first to 11 points wins
        DontDestroyMe.PongMode = DontDestroyMe.PongModes.ScoreLimitPong;
        PlayPong();
    }

    public void CountdownPong()
    {
        // Load the game scene
        //TODO: Add variable to set mode to Countdown pong
        // rules: timer counts  down, 2 halves of 2 minutes each
        DontDestroyMe.PongMode = DontDestroyMe.PongModes.CountdownPong;
        PlayPong();
    }

    // BRICK BREAKER
    public void PlayBrickbreaker()
    {
        // Load the game scene
        SceneManager.LoadScene("Brick Breaker");
    }

    public void PlaySpaceInvaders()
    {
        // Load the game scene
        SceneManager.LoadScene("Space Invaders");
    }

    public void PlayAstroids()
    {
        // Load the game scene
        SceneManager.LoadScene("Astroids");
    }

    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }

}
