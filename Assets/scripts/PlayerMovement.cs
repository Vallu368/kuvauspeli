using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed;
    [Header("Movement")]
    public float walkSpeed;
    public float sprintSpeed;

    public float groundDrag;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;

    // jump key
    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.C;

    // for checking if the player is on the ground
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Slope Handling")] // "jyrk‰t" kohat ei hidasta eik‰ nopeuta vauhtia jos k‰velee jostai alasp‰i
    public float maxSlopeAngle;
    private RaycastHit slopeHit; // RaycastHit = "a structured data object that is returned when a ray hits an object during a raycast"
    private bool exitingSlope; // this is so you can jump while on a slope

    public Transform  orientation;

    // for the keyboard input
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    // reference to rigidbody
    Rigidbody rb;

    public bool canPlayerMove = false;

    public MovementState state; // will store the current state the player is in
    public enum MovementState // enum = custom type that you can create in scripts
    {
        walking,
        sprinting,
        crouching,
        air
    }

    private void Start()
    {
        // koodi, ett‰ se ottaa sen oikean rigidbodyn ja freeze rigidbody et se ei randomisti l‰he k‰‰ntym‰‰n(?)
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        ResetJump();

        // save normal Y scale of the player
        startYScale = transform.localScale.y;

    }

    private void Update()
    {
        if (canPlayerMove == true) 
        {
            // ground check + remember to put the whatIsGround tag on stuff that you want to be grounded on
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

            // handle/apply the drag
            if (grounded)
            {
                rb.drag = groundDrag;
            }
            else
                rb.drag = 0;

            MyInput();

            SpeedControl();

            StateHandler();

          //  Debug.Log(state);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void StateHandler()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }

        // start crouch
        if (state == MovementState.crouching)
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            //rb.AddForce(Vector3.down * 0.8f, ForceMode.Impulse);
            moveSpeed = crouchSpeed;
        }

        // stop crouching
        if (state != MovementState.crouching)
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }

        // running/sprinting
        if(state == MovementState.sprinting)
        {
            moveSpeed = sprintSpeed;
        }
    }

    private void MyInput()
    {
        // crouching mode
        if (Input.GetKey(crouchKey) && grounded)
        {
            state = MovementState.crouching;
        }

        // sprinting mode
        else if (Input.GetKey(sprintKey) && grounded)
        {
            state = MovementState.sprinting;
        }

        // walking mode
        else if (grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }

        // air mode
        else
        {
            state = MovementState.air;
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on slope
        if (OnSlope() && !exitingSlope) // applying limitation and slope movement if not trying to exit a slope
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);
        }

        // on ground + adding force to player
        else if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }

        // in air
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }

        // turn off gravity while on slope
        rb.useGravity = !OnSlope();
    }

    // limit player speed manually
    private void SpeedControl()
    {
        // limiting speed on slope
        if (OnSlope() && !exitingSlope) // applying limitation and slope movement if not trying to exit a slope
        {
            if(rb.velocity.magnitude > moveSpeed)
            {
                rb.velocity = rb.velocity.normalized * moveSpeed;
            }
        }

        // limiting speed on ground or in air
        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            // limit speed if needed
            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, rb.velocity.z);
            }
        }

    }

    private void Jump()
    {
        exitingSlope = true;

        // reset Y velocity so you an always jump the exact same height
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // add force upwards
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse); // ForceMode.Impluse because it's only going to apply the force once
    }

    private void ResetJump()
    {
        readyToJump = true;
        exitingSlope = false;
    }

    private bool OnSlope()
    {
        // out slopeHit = whatever has been put in the slopeHit variable
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal); // calculates how steep the slope the player is standing on is
            return angle < maxSlopeAngle && angle != 0; // returns true if the angle is smaller than the maxSlopeAngle and not 0
        }

        return false; // if the raycast doesnt hit anything the bool will return false
    }

    // finds the correct direction relative to the slope
    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized; // normalize because it's a direction
    }
}
