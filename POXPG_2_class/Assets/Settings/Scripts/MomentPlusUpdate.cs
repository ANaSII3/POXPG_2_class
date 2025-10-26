using UnityEngine;

public class PlayerControllerUpdate : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeed = 15f;
    public float jumpForce = 7f;
    

    private float moveInput;
    private bool jumpPressed;
    private int jumpCount;
    public int maxJumps = 2;
    

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public GroundChecker groundChecker;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        jumpCount = 0;
        
    }

    void Update()
    {
        
        moveInput = Input.GetAxis("Horizontal");

        //flip
        if(moveInput < -0.01f)
        {
          spriteRenderer.flipX = true;
        }
        
        else if (moveInput > 0.01f)
        
        {
          spriteRenderer.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            jumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        if (groundChecker.isGrounded)
        {
            jumpCount = 0;
        }
        
        

        

        //double jump
        if (jumpPressed)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce);
            jumpCount++;
            jumpPressed = false;
        }
        
        //sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
        }

        else
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }

    }
}