using UnityEngine;

public class RoundManager : MonoBehaviour
{
    int currentRound = 1;
    public UIDisplayManager uiDisplayManager;

    void Start()
    {
        uiDisplayManager.UpdateRoundText(currentRound);
    }

    void Update()
    {

    }
}
