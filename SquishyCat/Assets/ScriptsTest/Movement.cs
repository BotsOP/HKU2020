using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    public int playerSpeed = 10;
    private bool facingRight = true;
    private float moveX;
    public float jumpStrength = 1000f;
    private readonly float multiplier = 800f;
    public bool isGrounded;
    void PlayerMove()
    {
        //controls
        moveX = Input.GetAxis("Horizontal");
        
        //animation
        //player Direction
        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        //physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    
    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    

    void start()
    {
        jumpStrength = 1000f;
        playerSpeed = 10;
    }
    void Update()
    {
        PlayerMove();

        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.S) && isGrounded == true)
        {

            jumpStrength += Time.deltaTime * multiplier;
        }
        else if (Input.GetKeyUp(KeyCode.S) && isGrounded == true)
        {
            jumpStrength = 1000;
        }
        if (jumpStrength > 1800)
        {
            jumpStrength = 1799;
        }

        if (jumpStrength < 1080)
        {
            playerSpeed = 9;
        }
        if (jumpStrength > 1080)
        {
            playerSpeed = 7;
        }
        if (jumpStrength > 1160)
        {
            playerSpeed = 2;
        }
        if (jumpStrength > 1240)
        {
            playerSpeed = 1;
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpStrength);
        Debug.Log(jumpStrength);
        jumpStrength = 1000f;
        isGrounded = false;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }
}
