using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageTruckCollide : MonoBehaviour
{
    private Animator animator;
    private PickupItem pickupItem;
    private float percentCollected;
    private bool doOnce;
    // returns percentage of total garbage collected, rounded to nearest percentage.
    // ex: person collects 3 out of 9 garbage on map -> returns "33"

    [HideInInspector] public bool animationFinished;
    // returns true when animation is finished; else false

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
        doOnce = false;
    }

    private void Update()
    {
        if (animationFinished)
        {
            GameObject.Find("WinScreenManager").GetComponent<WinScreenManager>().CheckAnimtionFinished();
            if (!doOnce)
            {
                GameObject.Find("WinScreenManager").GetComponent<WinScreenManager>().CheckScrapPercentage();
                doOnce = true;
            }            
        }
    }

    private void FixedUpdate()
    {
        if(pickupItem == null)
        {
            pickupItem = GameObject.FindAnyObjectByType<PickupItem>();
        }
        else
        {
            percentCollected = pickupItem.percentCollected;
        }
    }

    public void AlertObservers(string message)
    {
        animationFinished = message.Equals("animationEnded");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the garbage truck detects a player or ball...
        if(collision.gameObject.CompareTag("main_char"))
        {
            // Animation play
            this.GetComponent<SpriteRenderer>().enabled = false;
            animator.enabled = true;
            animator.Play(0);
            collision.gameObject.SetActive(false);

            // End Screen code...
        }
    }
}
