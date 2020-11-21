using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement2 : MonoBehaviour
{
    public float movementSpeed, jumpForce;

    bool isRight;

    public Animator anim;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isRight = true;
    }

    void Update()
    {
        var movement = Input.GetAxis("HorizontalArrow");
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
            isRight = false;

            anim.SetBool("walking", true);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
            isRight = true;

            anim.SetBool("walking", true);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetButtonDown("JumpArrow") && Mathf.Abs(rb.velocity.y) < 0.001)
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (movement == 0)
        {
            anim.SetBool("walking", false);
        }

        if (isRight == false)
            transform.localScale = new Vector2(.25f, transform.localScale.y);
        else
            transform.localScale = new Vector2(-.25f, transform.localScale.y);
    }
}
