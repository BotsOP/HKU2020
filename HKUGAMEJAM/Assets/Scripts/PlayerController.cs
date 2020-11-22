using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [SerializeField] bool useArrowKeys;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier = 3;
    [SerializeField] float MovementSpeed = 5;
    [SerializeField] float jumpForce = 10;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform feet;
    [SerializeField] int extraJumps = 2;
    public Animator anim;
    bool isGrounded;
    int jumpCount;
    float jumpCoolDown;
    float movement;
    bool isWalking;
    

    bool isRight;

    Rigidbody2D rb;

    void Start()
    {
        anim = gameObject.transform.GetChild(2).GetComponent<Animator>();
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

        if(Input.GetKeyDown(KeyCode.R)){
             Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
         }

        CheckGrounded();
    }

    void Move()
    {
        if(useArrowKeys)
            movement = Input.GetAxis("HorizontalArrow");
        else
            movement = Input.GetAxis("Horizontal");

        if(movement != 0)
            anim.SetBool("walking", true);
        else
            anim.SetBool("walking", false);

        if(isGrounded)
            anim.SetBool("jumping", false);
        else
            anim.SetBool("jumping", true);

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

        if (movement < 0)
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
            FindObjectOfType<AudioManager>().Play("PlayerLand");
        }

    }

    void Jump()
    {
        if(isGrounded || jumpCount < extraJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
            FindObjectOfType<AudioManager>().Play("PlayerJump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("MovingPlatform"))
            this.transform.parent = collision.transform;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("MovingPlatform"))
            this.transform.parent = null;
    }
}
