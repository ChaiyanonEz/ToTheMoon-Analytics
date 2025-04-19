using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalTime : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ResultText;

    void Start()
    {
        // Get the stored time from PlayerPrefs and display it
        float elapsedTime = PlayerPrefs.GetFloat("GameTime", 0f);
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        ResultText.text = string.Format("Time : {0:00} : {1:00}", minutes, seconds);
    }
}
