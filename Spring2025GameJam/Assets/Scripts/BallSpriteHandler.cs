using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpriteHandler : MonoBehaviour
{
    [SerializeField] private List<Sprite> ballStart = new List<Sprite>();
    private SpriteRenderer sr;
    private Animator animator;
    private int totalEnlarged;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        totalEnlarged = GetComponent<PickupItem>().totalEnlarged;

        animator.enabled = false;
    }

    private void FixedUpdate()
    {
        switch (GetComponent<PickupItem>().totalEnlarged)
        {
            case > 4:
                animator.enabled = true;
                sr.sprite = ballStart[5];
                break;
            case 4:
                sr.sprite = ballStart[4];
                break;
            case 3:
                sr.sprite = ballStart[3];
                break;
            case 2:
                sr.sprite = ballStart[2];
                break;
            case 1:
                sr.sprite = ballStart[1];
                break;
            default:
                sr.sprite = ballStart[0];
                break;
        }
    }
}
