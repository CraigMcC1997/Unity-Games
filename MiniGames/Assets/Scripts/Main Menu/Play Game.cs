using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void Play_Game()
    {
        // Load the game scene
        SceneManager.LoadScene("Pong Selection Screen");
    }

    public void LoadMainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }

}
