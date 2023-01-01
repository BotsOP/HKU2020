using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamster : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerCheck;
    public float posHamster;
    public float posPlayer;
    public float posHamsterDash;
    public float posPlayerDash;
    private Rigidbody2D rb2d;
    public float dashForce = 10000000f;
    public float dashBreak = 1000000f;
    public bool youCanDash;
    [SerializeField] private LayerMask whatIsPlayer;
    const float playerRadius = 6f;
    public float timer = 0.0f;
    public int seconds;
    public bool canTurn;
    public bool isDashing;
    public bool myFunctionCalled = false;
    public float distance;
    public Transform objectDetectionDown;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        seconds = (int)(timer % 60);
        posHamster = transform.position.x;
        posPlayer = player.transform.position.x;
        youCanDash = false;
        Collider2D[] playercolliders = Physics2D.OverlapCircleAll(playerCheck.position, playerRadius, whatIsPlayer);
        for (int i = 0; i < playercolliders.Length; i++)
        {
            if (playercolliders[i].gameObject != gameObject)
                youCanDash = true;
        }
        RaycastHit2D objectInfoDown = Physics2D.Raycast(objectDetectionDown.position, Vector2.down, distance);
        if(canTurn == true)
        {
            if (posHamster >= posPlayer)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
            if (posHamster <= posPlayer)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        if(youCanDash == true)
        {
            isDashing = true;
        }
        if(isDashing == false)
        {
            canTurn = true;
        }
        if(isDashing == true)
        {
            timer += Time.deltaTime;
            if ((timer >= 0) && (timer <= 0.1))
            {
                rb2d.velocity = Vector2.zero;
                canTurn = true;
                if (myFunctionCalled == false)
                {
                    posHamsterDash = transform.position.x;
                    posPlayerDash = player.transform.position.x;
                    myFunctionCalled = true;
                }
            }
            if ((timer >= 0.1) && (timer <= 1))
            {
                rb2d.velocity = Vector2.zero;
                canTurn = false;
            }
            if ((timer >= 1) && (timer <= 1.2))
            {
                canTurn = false;
                if (posHamsterDash >= posPlayerDash)
                {
                    rb2d.velocity = Vector2.zero;
                    rb2d.AddForce(new Vector2(-dashForce, 0f));
                }
                if (posHamsterDash <= posPlayerDash)
                {
                    rb2d.velocity = Vector2.zero;
                    rb2d.AddForce(new Vector2(dashForce, 0f));
                }
            }
            if ((timer >= 1.2) && (timer <= 1.6))
            {
                if (posHamsterDash >= posPlayerDash)
                {
                    rb2d.velocity = Vector2.zero;
                    rb2d.AddForce(new Vector2(-dashBreak, 0f));
                }
                if (posHamsterDash <= posPlayerDash)
                {
                    rb2d.velocity = Vector2.zero;
                    rb2d.AddForce(new Vector2(dashBreak, 0f));
                }
                canTurn = false;
            }
            if (timer >= 1.6)
            {
                rb2d.velocity = Vector2.zero;
                myFunctionCalled = false;
                canTurn = true;
                timer = 0;
                isDashing = false;
            }
        }
    }
}
