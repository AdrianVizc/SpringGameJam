using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class Timer : MonoBehaviour
{
    [SerializeField] private Animator loseAnimator;
    [SerializeField] private float minutes;
    [SerializeField] private float seconds;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private PlayerStartupAnimation animStart;
    [SerializeField] private LoseAnimationHandler animLose;
    [SerializeField] private MovementInput movement;
    [SerializeField] private GameObject itemHandler;

    private GameObject ball;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("player");
        ball = GameObject.FindWithTag("magnet_ball");

        loseAnimator.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (animStart.animationFinished)
        {
            Countdown();
        }
        if( animLose.animationFinished)
        {
            GameObject.Find("LoseScreenManager").GetComponentInChildren<LosingSceneManager>().CheckIfLostGame();
        }

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
            player.SetActive(false);
            ball.SetActive(false);
            itemHandler.SetActive(false);
            movement.enabled = false;
            loseAnimator.gameObject.SetActive(true);

        }
    }
}
