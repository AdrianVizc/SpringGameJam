using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopQuadrant : MonoBehaviour
{
    private GameObject player;
    private GameObject ball;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        ball = GameObject.FindGameObjectWithTag("magnet_ball");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            player.GetComponent<Animator>().SetInteger("quadrant", 1);
            ball.GetComponent<Animator>().SetInteger("quadrant", 1);
        }
    }
}
