using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement2 : MonoBehaviour
{
    public float movementSpeed, jumpForce;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            var movement = Input.GetAxis("HorizontalArrow");
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            var movement = Input.GetAxis("HorizontalArrow");
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetButtonDown("JumpArrow") && Mathf.Abs(rb.velocity.y) < 0.001)
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
