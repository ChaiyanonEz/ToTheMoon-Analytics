using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointControl : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI ScoreNumber;
    private GameTimerManager timerManager; // Reference to GameTimerManager

    void Start()
    {
        score = 0;
        // Get the GameTimerManager reference
        timerManager = FindObjectOfType<GameTimerManager>();
    }

    void Update()
    {
        // You can add any additional update logic here if needed
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            score += 1;
            ScoreNumber.text = "" + score;
            Destroy(other.gameObject);
        }

        if (score >= 7)
        {
            // Stop the timer when the player wins
            timerManager.StopTimer();
            // Load the victory scene (Scene 4)
            SceneManager.LoadScene(4);
        }
    }
}
