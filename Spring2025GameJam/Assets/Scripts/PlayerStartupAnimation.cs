using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerStartupAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private MovementInput movement;
    private GameObject player;
    private GameObject ball;
    [HideInInspector] public bool animationFinished;

    private void Start()
    {
        animationFinished = false;

        movement = transform.root.GetComponentInChildren<MovementInput>();
        player = GameObject.FindWithTag("player");
        ball = GameObject.FindWithTag("magnet_ball");

        if (movement != null)
        {
            movement.enabled = false;
        }
        if (player != null)
        {
            player.SetActive(false);
        }
        if (ball != null)
        {
            ball.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if( animationFinished )
        {
            if (movement != null)
            {
                movement.enabled = true;
            }
            if (player != null)
            {
                player.SetActive(true);
            }
            if (ball != null)
            {
                ball.SetActive(true);
            }
            animator.gameObject.SetActive(false);
            this.enabled = false;
        }
    }

    public void AlertObservers(string message)
    {
        animationFinished = message.Equals("animationEnded");
    }


}
