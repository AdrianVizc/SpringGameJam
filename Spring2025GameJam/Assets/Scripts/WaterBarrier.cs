using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("water"))
        {
            GameObject.Find("LoseScreenManager").GetComponentInChildren<LosingSceneManager>().CheckIfLostGame();
        }
    }
}
