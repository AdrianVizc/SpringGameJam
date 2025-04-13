using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Cinemachine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private ItemRotationHandler rotationHandler;
    [SerializeField] private int percentToIncrease;
    [SerializeField] private TMP_Text score;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    public float scaleIncrease;
    [HideInInspector] public int totalEnlarged;
    [HideInInspector] public float percentCollected; // DEV NOTE FOR NICK: this is the variable for total percent of objects collected

    private List<GameObject> pickupItems = new List<GameObject>();
    private List<GameObject> attachedItems = new List<GameObject>();

    private int minThreshold;
    private int currPickedUp;
    private int totalScore;
    private int totalPickedUp;

    private void Start()
    {
        pickupItems.AddRange(GameObject.FindGameObjectsWithTag("pickupable")); // List of all gameobjects that could be picked up
        minThreshold = Mathf.FloorToInt(pickupItems.Count * (percentToIncrease / 100f));
        scaleIncrease = scaleIncrease / 10;
        currPickedUp = 0;
        totalScore = 0;
        totalEnlarged = 0;
        totalPickedUp = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pickupable"))
        {
            // Add to total score based on item's value
            ++totalPickedUp;
            percentCollected = Mathf.Round(((float)totalPickedUp / (float)pickupItems.Count) * 100f);
            GameObject.Find("WinScreenManager").GetComponent<WinScreenManager>().scrapPercentage = percentCollected;
            Debug.Log(percentCollected);
            totalScore += collision.gameObject.GetComponent<ItemValue>().value;
            score.text = totalScore.ToString();

            // Rescale child objects
            collision.gameObject.transform.localScale = new Vector2(1, 1);
            attachedItems.Add(collision.gameObject);

            // Add to minThreshold and attach collision obj to ball
            collision.gameObject.tag = "Untagged";
            collision.gameObject.transform.parent = GameObject.FindObjectOfType<ItemRotationHandler>().transform;
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            ++currPickedUp;

            // Once minThreshold reached, increase ball size
            if (currPickedUp >= minThreshold)
            {
                currPickedUp = 0;
                ++totalEnlarged;

                rotationHandler.GetComponent<SphereCollider>().radius += scaleIncrease;
                transform.localScale = new Vector3(transform.localScale.x + scaleIncrease, transform.localScale.y + scaleIncrease);
                player.transform.localPosition = new Vector3(player.transform.localPosition.x, player.transform.localPosition.y + scaleIncrease - 0.1f, player.transform.localPosition.z);

                virtualCamera.m_Lens.OrthographicSize += scaleIncrease;
            }
        }
    }
}
