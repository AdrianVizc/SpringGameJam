using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosingSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject loseScreenPanel;
    private bool doOnce;

    private void Start()
    {
        doOnce = false;
        loseScreenPanel.SetActive(false);
    }

    private void Update()
    {
        CheckIfLostGame();
    }

    private void CheckIfLostGame()
    {
        bool timeIsOver = GameObject.Find("TimerDisplay").GetComponent<Timer>().timeIsOver;
        
        if (timeIsOver && !doOnce)
        {
            doOnce = true;
            Time.timeScale = 0f;
            loseScreenPanel.SetActive(true);
        }
    }
}
