using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed, jumpForce;
    bool isright, isleft;



    public Animator anim;
   
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.A))
        {

            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
            anim.SetBool("walking", true);
            print("walk trued");

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
           
            anim.SetBool("walking", true);
            print("walk trued");

        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001)
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (movement == 0)
        {
            anim.SetBool("walking", false);
            print("walk false");

        }
       



    }
}
