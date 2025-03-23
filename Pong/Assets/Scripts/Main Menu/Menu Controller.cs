using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayPong()
    {
        // Load the game scene
        SceneManager.LoadScene("Pong");
    }

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
