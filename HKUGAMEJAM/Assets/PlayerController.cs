using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier = 3;
    [SerializeField] float MovementSpeed = 5;
    [SerializeField] float jumpForce = 10;
    [SerializeField] float movementAcc;
    [SerializeField] float movementExtraAcc;
    [SerializeField] float movementExtraDeAcc;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        var movement = Input.GetAxis("Horizontal");
        if(movement > 0)
        {
            movementAcc += movementExtraAcc;
        }
        else if(movement <= 0 && movementAcc > 1)
            movementAcc -= movementExtraDeAcc;
        
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed * (movementAcc + 1);
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
