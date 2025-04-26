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
        if (Input.GetKeyDown(KeyCode.L))
        {
            AnalyticsManager.Instance.ReplayTotal++;
            AnalyticsManager.Instance.ReplayRate();
            
            Debug.Log($"ReplayTotal: {AnalyticsManager.Instance.ReplayTotal}");
            
            AnalyticsManager.Instance.PlayerIndex++;
            AnalyticsManager.Instance.ReplayRate();
            
            //Debug.Log($"ReplayTotal: {AnalyticsManager.Instance.ReplayTotal}");
            
            timerManager.StopTimer();
            SceneManager.LoadScene(4);
        }
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
            AnalyticsManager.Instance.ReplayTotal++;
            AnalyticsManager.Instance.ReplayRate();
            
            Debug.Log($"ReplayTotal: {AnalyticsManager.Instance.ReplayTotal}");
            
            AnalyticsManager.Instance.PlayerIndex++;
            AnalyticsManager.Instance.ReplayRate();
            
            //Debug.Log($"Player Total: {AnalyticsManager.Instance.PlayerIndex}");
            
            // Stop the timer when the player wins
            timerManager.StopTimer();
            // Load the victory scene (Scene 4)
            SceneManager.LoadScene(4);
        }
    }
}
