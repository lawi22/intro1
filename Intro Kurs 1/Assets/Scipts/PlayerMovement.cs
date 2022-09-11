using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rigidBody2D;

    private SpriteRenderer spriteRenderer;

    private Animator animator;

    public GameObject groundCheck;
    private bool isGrounded;
    float moveDirection = 0f;
    bool isJumpPressed = false;
    private bool isMoving;

    int number = 1;
    int number2 = 2;

    bool isTrue;

    Vector3 myOwnPosition;

    public float movementSpeed = 5f;

    [SerializeField] float jumpingSpeed = 15f;
    [SerializeField] float jumpForce = 2f;

    private bool isFacingLeft;

    private Vector3 velocity;
    public float smoothTime = 0.2f;

    [SerializeField] private LayerMask whatIsGround;


    // Start is called before the first frame update
    public void Start()
    {

        isFacingLeft = true;
        myOwnPosition = gameObject.transform.position;

        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        animator = gameObject.GetComponent<Animator>();

        List<int> listOfInts = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = (Input.GetAxis("Horizontal"));
        if (Mathf.Abs(moveDirection) > 0.05)
        {
            isMoving = true;
        } else
        {
            isMoving = false;
        }

        if (Input.GetKeyDown(KeyCode.W) == true ^ Input.GetKeyDown(KeyCode.Space) == true)
        {
            isJumpPressed = true;
            animator.SetTrigger("DoJump");

        }
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("Speed", Mathf.Abs(moveDirection));
    }
    private void FixedUpdate() 
        {
            isGrounded = false;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f, whatIsGround);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    isGrounded = true;
                }

            }
            Vector3 calculatedMovement = Vector3.zero;

            float verticalVelocity = 0f;

        if (isGrounded == false)
        {
            verticalVelocity = rigidBody2D.velocity.y;
        }

            calculatedMovement.x = movementSpeed * 100 * moveDirection * Time.fixedDeltaTime;
            calculatedMovement.y = verticalVelocity;
            Move(calculatedMovement, isJumpPressed);
            isJumpPressed = false;
    }
    private void Move(Vector3 moveDirection, bool isJumpPressed)
    {
        //GameObject.transform.Translate(moveDirection);
        //Vector3 moveSideWaysDirection = new Vector3(moveDirection.x, )

        rigidBody2D.velocity = Vector3.SmoothDamp(rigidBody2D.velocity, moveDirection, ref velocity, smoothTime);

        if (isJumpPressed == true && isGrounded == true)
        {
            rigidBody2D.AddForce(new Vector2(0f, jumpForce * 100));
        }

        if (moveDirection.x > 0f && isFacingLeft == true) {
            FlipSpriteDirection();

        }
        else if (moveDirection.x < 0f && isFacingLeft == false) {
            FlipSpriteDirection();


        }

    }

    private void FlipSpriteDirection()
    {
        spriteRenderer.flipX = !isFacingLeft;
        isFacingLeft = !isFacingLeft;
    }
    private int Calculate(int numberA, int numberB)
    {
        int sum = numberA + numberB;
        print(sum);
        return sum;
    }

    public bool IsFalling()
    {
        if (rigidBody2D.velocity.y < -1f)
        {
            return true;
        }
        return false;
    }


}
