using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool jumpInput;
    private Rigidbody2D rigidBody;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatisGround;


    public void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisGround);
        moveInput = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(moveInput * speed, rigidBody.velocity.y);
    }

    public void Update()
    {
        if (!isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetButton("Jump")))
        {
            rigidBody.velocity = Vector2.up * jumpForce;
        }
    }
}
