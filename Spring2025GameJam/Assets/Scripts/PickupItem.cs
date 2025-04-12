using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int percentToIncrease;
    public float scaleIncrease;
    private List<GameObject> pickupItems = new List<GameObject>();
    private List<GameObject> attachedItems = new List<GameObject>();
    private int minThreshold;
    private int currPickedUp;

    private void Start()
    {
        pickupItems.AddRange(GameObject.FindGameObjectsWithTag("pickupable")); // List of all gameobjects that could be picked up
        minThreshold = Mathf.FloorToInt(pickupItems.Count * (percentToIncrease / 100f));
        scaleIncrease = scaleIncrease / 10;
        currPickedUp = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pickupable"))
        {
            // Rescale child objects
            attachedItems.Add(collision.gameObject);
            foreach(GameObject obj in attachedItems)
            {
                obj.transform.localScale = new Vector3(obj.transform.localScale.x * (1.1f - scaleIncrease), obj.transform.localScale.y * (1.1f - scaleIncrease));
            }

            // Destroy the pickupable item and add to minThreshold
            collision.gameObject.tag = "Untagged";
            collision.gameObject.transform.parent = transform;
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            ++currPickedUp;

            if (currPickedUp >= minThreshold)
            {
                transform.localScale = new Vector3(transform.localScale.x + scaleIncrease, transform.localScale.y + scaleIncrease);
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + scaleIncrease * 1.25f);
            }
        }
    }
}
