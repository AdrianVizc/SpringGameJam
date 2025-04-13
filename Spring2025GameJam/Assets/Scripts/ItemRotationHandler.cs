using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotationHandler : MonoBehaviour
{
    private Transform parentObj;
    private GameObject magnetBall;
    private Vector3 currPos;
    private Vector3 lastpos;
    private Vector3 movement;

    private void Start()
    {
        parentObj = transform.parent;
        magnetBall = GameObject.FindGameObjectWithTag("magnet_ball");
    }

    private void Update()
    {
         //transform.localScale = magnetBall.transform.localScale;

         currPos = parentObj.position;
         movement = currPos - lastpos;
         
         if(movement != Vector3.zero)
         {
             Vector3 direction = movement.normalized;
             float distance = movement.magnitude;
         
             Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);
         
             float radius = transform.localScale.y * 0.5f;
             float angle = (distance / (2 * Mathf.PI * transform.localScale.x * 0.5f)) * 360f;

            if (!Input.GetKey(KeyCode.S))
            {
                transform.Rotate(Vector3.right, -angle, Space.Self);
            }
            else
            {
                transform.Rotate(Vector3.right, angle, Space.Self);
            }
        }
         
         lastpos = currPos;
    }
}
