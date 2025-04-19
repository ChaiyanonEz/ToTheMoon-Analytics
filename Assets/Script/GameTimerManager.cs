using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimerManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimerText;
    float elapsedTime;
    bool isTimerRunning = true;

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            TimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }
    }

    // Method to stop the timer
    public void StopTimer()
    {
        isTimerRunning = false;
        // Save elapsed time to PlayerPrefs when the game stops
        PlayerPrefs.SetFloat("GameTime", elapsedTime);
    }

    // Method to start or resume the timer
    public void StartTimer()
    {
        isTimerRunning = true;
    }

    // Method to reset the timer
    public void ResetTimer()
    {
        elapsedTime = 0;
        TimerText.text = "00 : 00";
        StartTimer();
    }
}
