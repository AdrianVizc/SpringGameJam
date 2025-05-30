using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopQuadrant : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ball;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            player.GetComponent<Animator>().SetInteger("quadrant", 1);
            ball.GetComponent<Animator>().SetInteger("quadrant", 1);
        }
    }
}
