using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController2D1 : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .28f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [Range(0, 3)] [SerializeField] private float m_FlySpeed = 1.6f;
    [Range(0, 3)] [SerializeField] private float m_FlySpeed1 = 1.5f;
    [Range(0, 3)] [SerializeField] private float m_FlySpeed2 = 1.3f;
    [Range(0, 3)] [SerializeField] private float m_FlySpeed3 = 1.1f;
    [SerializeField] private float m_JumpForceMultiplier = 5f;
    [SerializeField] private int m_HeadAttackForce = 0;
    [SerializeField] private int m_BottemAttackForce = 0;
    [SerializeField] private int m_FrontAttackForce = 0;
    [SerializeField] private int m_BackAttackForce = 0;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private LayerMask m_WhatIsEnemy;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private Transform m_FrontCheck;// A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
    [SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching

    public Animator playerAnimator;
    const float k_GroundedRadius = .1f; // Radius of the overlap circle to determine if grounded
    const float k_GroundedOnEnemyRadius = .01f;
    public bool m_Grounded;            // Whether or not the player is grounded.
    public bool m_GroundedOnEnemy;
    public bool m_FrontHit;  // Whether or not the player is grounded.
    const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
    const float k_FrontRadius = .2f;
    private Rigidbody2D m_Rigidbody2D;
    public bool TimesJump;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Restart"))
        {
            SceneManager.LoadScene("LevelTester");
        }

        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] groundcolliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < groundcolliders.Length; i++)
        {
            if (groundcolliders[i].gameObject != gameObject)
                m_Grounded = true;
        }
        m_GroundedOnEnemy = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] enemycolliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedOnEnemyRadius, m_WhatIsEnemy);
        for (int i = 0; i < enemycolliders.Length; i++)
        {
            if (enemycolliders[i].gameObject != gameObject)
                m_GroundedOnEnemy = true;
        }
        m_FrontHit = false;
        Collider2D[] frontcolliders = Physics2D.OverlapCircleAll(m_FrontCheck.position, k_FrontRadius, m_WhatIsGround);
        for (int j = 0; j < frontcolliders.Length; j++)
        {
            if (frontcolliders[j].gameObject != gameObject)
                m_FrontHit = true;
        }

    }

    public void Move(float move, bool crouch, bool jump)
    {
        if ((!m_Grounded && !m_GroundedOnEnemy) && (GetComponent<Rigidbody2D>().velocity.y > 5))
        {
            move *= m_FlySpeed;
        }
        if ((!m_Grounded && !m_GroundedOnEnemy) && (GetComponent<Rigidbody2D>().velocity.y > 1))
        {
            move *= m_FlySpeed1;
        }
        if ((!m_Grounded && !m_GroundedOnEnemy) && (GetComponent<Rigidbody2D>().velocity.y > 0))
        {
            move *= m_FlySpeed2;
        }
        if ((!m_Grounded && !m_GroundedOnEnemy) && (GetComponent<Rigidbody2D>().velocity.y < 0))
        {
            move *= m_FlySpeed3;
        }
        if ((!m_Grounded && !m_GroundedOnEnemy) && (GetComponent<Rigidbody2D>().velocity.y < 5))
        {
            move = move;
        }
        if (m_FrontHit == false)
        {
            playerAnimator.SetFloat("Speed", Mathf.Abs(move));
            playerAnimator.SetBool("Speeds", true);
        }
        if (m_FrontHit == true)
        {
            playerAnimator.SetFloat("Speed", 0f);
            playerAnimator.SetBool("Speeds", false);

        }
        // If crouching, check to see if the character can stand up
        if (!crouch)
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;
            }
        }

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl || m_GroundedOnEnemy)
        {

            // If crouching
            if (crouch)
            {
                // Reduce the speed by the crouchSpeed multiplier
                if (m_Grounded || m_GroundedOnEnemy)
                {
                    move *= m_CrouchSpeed;
                }
                else
                {
                    move = move;
                }

                // Disable one of the colliders when crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = false;
            }
            else
            {
                // Enable the collider when not crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;
            }

            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            if (move == 0)
            {
                m_FrontAttackForce = 0;
                m_BackAttackForce = 0;
            }
            if (move < 0)
            {
                m_FrontAttackForce = 1;
            }
            if (move > 0)
            {
                m_FrontAttackForce = 1;
            }
        }
        // If the player should jump...
        if ((m_Grounded || m_GroundedOnEnemy) && jump && TimesJump)
        {
            // Add a vertical force to the player.
            TimesJump = false;
            m_Grounded = false;
            m_GroundedOnEnemy = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));

        }
        if ((m_Grounded || m_GroundedOnEnemy) && !TimesJump)
        {
            TimesJump = true;
        }
        if ((m_Grounded && crouch) || (m_GroundedOnEnemy && crouch))
        {
            m_JumpForce += m_JumpForceMultiplier;

        }
        if ((!m_Grounded && !m_GroundedOnEnemy) || !crouch)
        {
            m_JumpForce = 900;

        }
        if (m_JumpForce >= 1500)
        {
            m_JumpForce = 1500;
            playerAnimator.SetBool("IsPrep2", true);
        }
        if (m_JumpForce >= 901)
        {
            playerAnimator.SetBool("IsPrep1", true);
        }
        if (m_JumpForce <= 901)
        {
            playerAnimator.SetBool("IsPrep1", false);
            playerAnimator.SetBool("IsPrep2", false);
        }
        if (!m_Grounded && !m_GroundedOnEnemy)
        {
            playerAnimator.SetBool("IsJumping", true);
            if (GetComponent<Rigidbody2D>().velocity.y < -0.1 && !crouch)
            {
                m_BottemAttackForce = 1;
                m_HeadAttackForce = 0;
                playerAnimator.SetBool("IsJumpingDown", true);
                playerAnimator.SetBool("IsJumpingDownFast", false);
                playerAnimator.SetBool("IsJumpingMiddle", false);
                playerAnimator.SetBool("IsJumpingUp", false);
            }
            if (GetComponent<Rigidbody2D>().velocity.y < -0.1 && crouch)
            {
                m_BottemAttackForce = 2;
                m_HeadAttackForce = 0;
                playerAnimator.SetBool("IsJumpingDownFast", true);
                playerAnimator.SetBool("IsJumpingDown", true);
                playerAnimator.SetBool("IsJumpingMiddle", false);
            }
            if (GetComponent<Rigidbody2D>().velocity.y > 0.1)
            {
                m_BottemAttackForce = 0;
                m_HeadAttackForce = 1;
                playerAnimator.SetBool("IsJumpingUp", true);
            }
            if (GetComponent<Rigidbody2D>().velocity.y < 1)
            {
                playerAnimator.SetBool("IsJumpingUp", false);
                if ((!m_Grounded || !m_GroundedOnEnemy) && GetComponent<Rigidbody2D>().velocity.y > -0.1)
                {
                    playerAnimator.SetBool("IsJumpingMiddle", true);
                }
            }
            if (GetComponent<Rigidbody2D>().velocity.y > 18)
            {
                m_HeadAttackForce = 2;
                m_BottemAttackForce = 0;
                
            }
            if (GetComponent<Rigidbody2D>().velocity.y == 0)
            {
                playerAnimator.SetBool("IsJumping", false);
                playerAnimator.SetBool("IsJumpingDown", false);
                playerAnimator.SetBool("IsJumpingDownFast", false);
                playerAnimator.SetBool("IsJumpingMiddle", false);
                playerAnimator.SetBool("IsJumpingUp", false);
            }
        }
        if (m_GroundedOnEnemy || m_Grounded)
        {
            m_BottemAttackForce = 0;
            m_HeadAttackForce = 0;
            playerAnimator.SetBool("IsJumping", false);
            playerAnimator.SetBool("IsJumpingDown", false);
            playerAnimator.SetBool("IsJumpingDownFast", false);
            playerAnimator.SetBool("IsJumpingMiddle", false);
            playerAnimator.SetBool("IsJumpingUp", false);

        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}