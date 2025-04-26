using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
/*public class AnalyticsManger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnBuyItem("Item A",1);
        }
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            OnBuyItem("Item B",1);
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            OnBuyItem("Item C",1);
        }
        
    }

    private async void Initialize()
    {
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
    }

    private void OnBuyItem(string item, int count)
    {
        CustomEvent exampleEvent = new CustomEvent("BuyNewItem")
        {
            { "NameOfItem",item},{ "Count",count}
        };
    
        AnalyticsService.Instance.RecordEvent(exampleEvent);
        Debug.Log($"Record Event Buy {item} count {count}");
    }
}*/

/*public class GameAnalytics : MonoBehaviour
{
    string playerId;
    async void Start()
    {
        playerId = Guid.NewGuid().ToString();
        
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();

        // ส่ง event เมื่อผู้เล่นเข้าเกม
        CustomEvent loginEvent = new CustomEvent("CCU_Event");
        {
            { "timestamp", DateTime.UtcNow.ToString("o") },
            { "player_id", SystemInfo.deviceUniqueIdentifier }
        };
    }

    void OnApplicationQuit()
    {
        // ส่ง event เมื่อผู้เล่นออกจากเกม
        AnalyticsService.Instance.CustomData("player_logged_out", new Dictionary<string, object>
        {
            { "timestamp", DateTime.UtcNow.ToString("o") },
            { "player_id", SystemInfo.deviceUniqueIdentifier }
        });
    }
}*/
