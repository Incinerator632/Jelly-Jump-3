using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float timeValue = 120f;
    public TextMeshProUGUI timerText;
    public UnityEvent onTimerCompleted;

    void Update()
    {
        if (timeValue > 0f)
        {
            timeValue -= Time.deltaTime;

            if (timeValue <= 0f)
            {
                onTimerCompleted?.Invoke();
                timeValue = 0f;
            }
        }
        //if (timeValue > 0)
        //{
        //timeValue -= Time.deltaTime;
        //}
        //else
        //{
        //timeValue = 0;
        //}

        DisplayTime(timeValue);
    }

    void DisplayTime(float timetoDisplay)
    {
        if (timetoDisplay < 0)
        {
            timetoDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timetoDisplay / 60);
        float seconds = Mathf.FloorToInt(timetoDisplay % 60);

        timerText.text = string.Format("TIME: {0:00}:{1:00}", minutes, seconds);
    }
}
