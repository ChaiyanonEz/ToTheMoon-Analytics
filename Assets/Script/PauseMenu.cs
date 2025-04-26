using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool PauseGame = false;
    public GameObject pauseMenuUI;
    public Behaviour PauseCanvas;
    
    public int ccuIndex;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseCanvas.enabled = !PauseCanvas.enabled;

            if (!PauseCanvas.enabled)
            {
                PauseGame = true;
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume() 
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PauseGame =  false;
        PauseCanvas.enabled = PauseCanvas.enabled;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Exit()
    {
        /*ccuIndex--;
        AnalyticsManager.Instance.CcuAnalytics(ccuIndex);
        AnalyticsService.Instance.Flush();
        Debug.Log($"CCU Event {ccuIndex}");*/
        //Debug.Log("Quitting game...");
        Application.Quit();
    }

}
