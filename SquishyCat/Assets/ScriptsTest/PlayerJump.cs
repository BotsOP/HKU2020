using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]

    
    private float jumpStrength = 250f;
    private readonly float multiplier = 100f;
    public bool isGrounded;


    void start()
    {
        jumpStrength = 250f;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {

            jumpStrength += Time.deltaTime * multiplier;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }
        if (jumpStrength > 450)
        {
            jumpStrength = 449;
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpStrength);
        Debug.Log(jumpStrength);
        jumpStrength = 250f;
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