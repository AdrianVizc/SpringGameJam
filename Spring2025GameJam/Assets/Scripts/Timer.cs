using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float minutes;
    [SerializeField] private float seconds;
    [SerializeField] private TMP_Text timerText;

    public bool timeIsOver;

    private void Start()
    {
        timeIsOver = false;
    }

    private void Update()
    {
        Countdown();
    }

    private void Countdown()
    {
        if (minutes > 0 || seconds > 0)
        {
            seconds -= Time.deltaTime;
            if (seconds < -1)
            {
                seconds = 59;
                minutes -= 1;
            }
            if (seconds < 9)
            {
                timerText.text = Mathf.FloorToInt(minutes).ToString() + ":0" + Mathf.CeilToInt(seconds).ToString();
            }
            else
            {
                timerText.text = Mathf.FloorToInt(minutes).ToString() + ":" + Mathf.CeilToInt(seconds).ToString();
            }            
        }
        else
        {
            timeIsOver = true;
        }
    }
}
