using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour
{
    [SerializeField] private GameObject person;
    [SerializeField] private GameObject ball;
    [SerializeField] float acceleration;
    [SerializeField] float steering;
    [SerializeField] float maxSpeed;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveInput = -Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        rb.AddForce(transform.up * moveInput * acceleration);

        person.GetComponent<Animator>().SetBool("isMoving", rb.velocity.magnitude > 0.1f);
        ball.GetComponent<Animator>().SetBool("isMoving", rb.velocity.magnitude > 0.1f);
        //if (rb.velocity.magnitude > 0.1f)
        {
            float direction = Mathf.Sign(Vector2.Dot(rb.velocity, transform.up));
            rb.MoveRotation(rb.rotation - turnInput * steering * direction);
        }

        //if (rb.velocity.magnitude > maxSpeed)
        {
            //rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
