using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
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

            // Destroy the pickupable item and add to minThreshold
            collision.gameObject.tag = "Untagged";
            collision.gameObject.transform.parent = GameObject.FindObjectOfType<ItemRotationHandler>().transform;
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            ++currPickedUp;

            if (currPickedUp >= minThreshold)
            {
                currPickedUp = 0;

                foreach (GameObject obj in attachedItems)
                {
                    obj.transform.localScale *= 1.1f - scaleIncrease;
                }
                transform.localScale = new Vector3(transform.localScale.x + scaleIncrease, transform.localScale.y + scaleIncrease);
                player.transform.localPosition = new Vector3(player.transform.localPosition.x, player.transform.localPosition.y + scaleIncrease, player.transform.localPosition.z);
            }
        }
    }
}
