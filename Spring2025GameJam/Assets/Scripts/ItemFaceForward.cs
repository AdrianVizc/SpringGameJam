using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFaceForward : MonoBehaviour
{
    [SerializeField] private GameObject rando;
    private void Update()
    {
        transform.LookAt(rando.transform);
    }
}
