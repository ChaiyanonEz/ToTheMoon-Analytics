using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    //public int ReplayTotal;
    public void StartGame ()
    {
        //AnalyticsManager.Instance.ReplayTotal++;
        //AnalyticsManager.Instance.ReplayRate();
        
        //Debug.Log($"ReplayTotal: {AnalyticsManager.Instance.ReplayTotal}");
        //Debug.Log($"ReplayIndex: {AnalyticsManager.Instance.ReplayIndex}");
        
        SceneManager.LoadScene(3);
    }
    
    public void ReplayGame ()
    {
        //AnalyticsManager.Instance.ReplayTotal++;
        AnalyticsManager.Instance.ReplayIndex++;
        //AnalyticsService.Instance.Flush();
        
        //Debug.Log($"ReplayTotal: {AnalyticsManager.Instance.ReplayTotal}");
        Debug.Log($"ReplayIndex: {AnalyticsManager.Instance.ReplayIndex}");
        
        SceneManager.LoadScene(3);
    }

    public void Howtoplay()
    {
        SceneManager.LoadScene(1);
    }

    public void Credit()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        /*ccuIndex--;
        AnalyticsManager.Instance.CcuAnalytics(ccuIndex);
        AnalyticsService.Instance.Flush();
        Debug.Log($"CCU Event {ccuIndex}");*/
        Application.Quit();
    }
}
