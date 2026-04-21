using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private PlayerInputSystem playerInputSys; //input system reference

    public Rigidbody2D rb;
    public float moveSpeed = 1f;
    public float jumpforce = 1f;
    public float lowjumpMultiplier = 2f;
    public float fallMultiplier = 3f;
    public bool isGrounded = true;


    void Awake()
    {
        playerInputSys = new PlayerInputSystem(); //initialising the input system

    }
    void OnEnable()
    {
        playerInputSys.Enable(); //needed for the input system
    }
    void OnDisable()
    {
        playerInputSys.Disable(); //needed for the input system
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 playerInput = playerInputSys.Player.Move.ReadValue<Vector2>(); //reads the player's input from the input system and turns it into a vector2
        rb.linearVelocity = new Vector2(playerInput.x * moveSpeed, rb.linearVelocity.y);

        if (playerInput != Vector2.zero)
        {
            //anim.SetBool("isWalking", true);
            if (playerInput.x < 0)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f); //rotates the player left or right based on input
            }
            else if (playerInput.x > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            /*
            if (!walkingSound.isPlaying)
            {
                walkingSound.Play();
            }

        }
        else
        {
            anim.SetBool("isWalking", false);
            walkingSound.Stop();*/
        }

        if(playerInputSys.Player.Jump.WasPressedThisFrame() && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        if(rb.linearVelocity.y < 0f) //falling
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        else if(rb.linearVelocity.y > 0f && !playerInputSys.Player.Jump.IsPressed()) //low jump
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowjumpMultiplier - 1) * Time.fixedDeltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
