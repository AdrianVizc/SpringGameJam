using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float minutes;
    [SerializeField] private float seconds;
    [SerializeField] private TMP_Text timerText;

    private void Update()
    {
        Countdown();
    }

    private void Countdown()
    {
        if (minutes > 0 || seconds > 0)
        {
            seconds -= Time.deltaTime;
            if (seconds < 0)
            {
                seconds = 60;
                minutes -= 1;
            }
            if (seconds < 10)
            {
                timerText.text = Mathf.FloorToInt(minutes).ToString() + ":0" + Mathf.FloorToInt(seconds).ToString();
            }
            else
            {
                timerText.text = Mathf.FloorToInt(minutes).ToString() + ":" + Mathf.FloorToInt(seconds).ToString();
            }            
        }
    }
}
