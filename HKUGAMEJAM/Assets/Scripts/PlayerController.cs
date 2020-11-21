using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] bool useArrowKeys;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier = 3;
    [SerializeField] float MovementSpeed = 5;
    [SerializeField] float jumpForce = 10;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform feet;
    [SerializeField] Transform head;
    bool isGrounded;
    int jumpCount;
    float jumpCoolDown;
    float movement;
    [SerializeField] int extraJumps = 2;

    bool isRight;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isRight = true;
    }

    void Update()
    {
        Move();
        if (useArrowKeys)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                Jump();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W))
                Jump();
        }

        CheckGrounded();
    }

    void Move()
    {
        if(useArrowKeys)
            movement = Input.GetAxis("HorizontalArrow");
        else
            movement = Input.GetAxis("Horizontal");

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (useArrowKeys)
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }

            else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }

        else
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }

            else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.W))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }

        if (movement <= 0)
        {
            isRight = false;
            transform.localScale = new Vector2(.25f, transform.localScale.y);
        }
        else if(movement > 0)
        {
            isRight = true;
            transform.localScale = new Vector2(-.25f, transform.localScale.y);
        }

    }

    void CheckGrounded()
    {
        if(Physics2D.OverlapCircle(feet.position, 0.5f, groundLayer))
        {
            isGrounded = true;
            jumpCount = 0;
            jumpCoolDown = Time.time + 0.2f;
        } else if(Time.time < jumpCoolDown)
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }

    }

    void Jump()
    {
        if(isGrounded || jumpCount < extraJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }
    }


}
