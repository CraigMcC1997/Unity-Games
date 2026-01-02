using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    int currentRound = 1;
    const int MAX_ROUNDS = 5;
    public UIDisplayManager uiDisplayManager;
    public BB_Score_Manager scoreManager;
    public Brick_Spawner brickSpawner;

    void Start()
    {
        uiDisplayManager.UpdateRoundText(currentRound);
    }

    void updateRound()
    {
        currentRound++;
        scoreManager.ResetStats();
        uiDisplayManager.UpdateRoundText(currentRound);
        brickSpawner.CreateBrickLayout();
    }

    void checkForWin()
    {
        if (currentRound >= MAX_ROUNDS)
        {
            SceneManager.LoadScene("Game Win");
        }
    }

    void Update()
    {
        if (scoreManager.GetScore() >= scoreManager.GetMaxScore())
        {
            updateRound();
        }
    }
}
