using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageTruckCollide : MonoBehaviour
{
    private PickupItem pickupItem;
    private float percentCollected;
    // returns percentage of total garbage collected, rounded to nearest percentage.
    // ex: person collects 3 out of 9 garbage on map -> returns "33"

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the garbage truck detects a player or ball...
        if(collision.gameObject.CompareTag("main_char"))
        {
            // Do something...
        }
    }
}
