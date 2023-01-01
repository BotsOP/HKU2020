using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    const float playerRadius = 4f;
    public bool wakeUp;
    [SerializeField] private Transform playerCheck;
    [SerializeField] private LayerMask whatIsPlayer;
    public Transform objectDetectionDown;
    public float distance;
    public bool isGrounded;
    private Rigidbody2D rb2d;
    public float jumpForce = 4000000f;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = false;
        RaycastHit2D objectInfoDown = Physics2D.Raycast(objectDetectionDown.position, Vector2.down, distance);
        if ((objectInfoDown.collider == true) && (objectInfoDown.collider.tag == "ground"))
        {
            isGrounded = true;
        }
        wakeUp = false;
        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] playercolliders = Physics2D.OverlapCircleAll(playerCheck.position, playerRadius, whatIsPlayer);
        for (int i = 0; i < playercolliders.Length; i++)
        {
            if (playercolliders[i].gameObject != gameObject)
                wakeUp = true;
        }
        if (wakeUp == true)
        {
            if ((Input.GetButton("Jump")) && (isGrounded == true))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0f, jumpForce));
            }
        }

    }
}
