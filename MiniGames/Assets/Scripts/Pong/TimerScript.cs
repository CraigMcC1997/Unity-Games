using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float timelimitSeconds = 100;
    public bool isRunning = false;
    public TMP_Text timerText;

    public void StartTimer(float timeInSeconds)
    {
        timelimitSeconds = timeInSeconds;
        isRunning = true;
    }

    public void PauseTimer()
    {
        isRunning = false;
    }

    public void ResumeTimer()
    {
        isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (timelimitSeconds >= 0)
            {
                timelimitSeconds -= Time.deltaTime;
                UpdateTimerDisplay(timelimitSeconds);
            }
            else
            {
                timelimitSeconds = 0;
                isRunning = false;
                // Timer has finished
            }
        }
    }

    void UpdateTimerDisplay(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
