using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void Play_Game()
    {
        // Load the game scene
        SceneManager.LoadScene(1); //SceneManager.GetActiveScene().buildIndex + 1
    }

    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }

}
