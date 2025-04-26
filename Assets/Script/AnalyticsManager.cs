using System;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;
using CustomEvent = Unity.VisualScripting.CustomEvent;

public class AnalyticsManager : MonoBehaviour
{
    string playerId;

    public int ReplayIndex = 0;
    public int ReplayTotal = 0;
    
    public float elapsedTime = 0;
    public int PlayerIndex = 0;
    
    public static AnalyticsManager Instance;
    private bool _isInitialized = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private async void Start()
    {
        
        playerId = Guid.NewGuid().ToString();
        
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
        _isInitialized = true;
        
        CcuAnalytics();
    }

    private void Update()
    {
        
    }

    public void CcuAnalytics()
    {
        Unity.Services.Analytics.CustomEvent loginEvent = new Unity.Services.Analytics.CustomEvent("player_entered");
        loginEvent["player_time"] = DateTime.UtcNow.ToString("o");
        loginEvent["player_id"] = playerId;
        
        AnalyticsService.Instance.RecordEvent(loginEvent);
        AnalyticsService.Instance.Flush();
        
        Debug.Log("[Analytics] Sending Event: player_entered");
        //Debug.Log($"timestamp: {loginEvent["timestamp"]}");
        Debug.Log($"player_id: {playerId} ");
        Debug.Log($"player_entered: {DateTime.UtcNow.ToString("o")}");
    }

    void OnApplicationQuit()
    {
        Unity.Services.Analytics.CustomEvent logoutEvent = new Unity.Services.Analytics.CustomEvent("player_exited");
        logoutEvent["player_time"] = DateTime.UtcNow.ToString("o");
        logoutEvent["player_id"] = playerId;

        AnalyticsService.Instance.RecordEvent(logoutEvent);
        AnalyticsService.Instance.Flush();
        
        Debug.Log("[Analytics] Sending Event: player_exited");
        //Debug.Log($"timestamp: {logoutEvent["timestamp"]}");
        Debug.Log($"session_id: {playerId}");
        Debug.Log($"player_exited: {DateTime.UtcNow.ToString("o")}");

    }

    public void ReplayRate()
    {
        Unity.Services.Analytics.CustomEvent ReplayEvent = new Unity.Services.Analytics.CustomEvent("replay_event");
        ReplayEvent["replay_index"] = ReplayIndex;
        ReplayEvent["replay_total"] = ReplayTotal;
        
        AnalyticsService.Instance.RecordEvent(ReplayEvent);
        AnalyticsService.Instance.Flush();
        
        Debug.Log($"Total Play {ReplayTotal}");
        Debug.Log($"Number of Replays {ReplayIndex}");
    }
    
    public void TimeToComplete(float elapsedTime)
    {
        Unity.Services.Analytics.CustomEvent TimeEvent = new Unity.Services.Analytics.CustomEvent("time_event");
        TimeEvent["time_complete"] = elapsedTime;
        TimeEvent["player_complete"] = PlayerIndex;
        
        AnalyticsService.Instance.RecordEvent(TimeEvent);
        AnalyticsService.Instance.Flush();
        
        Debug.Log($"TimeToComplete Sent | Time: {elapsedTime} seconds");
        Debug.Log($"Player Complete {PlayerIndex}");
    }
}


