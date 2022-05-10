using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    [Header("References")]
    public Transform orientaion;
    public Rigidbody rb;
    public LayerMask whatIsWall;

    [Header("Climbing")]
    public float climbSpeed;

    private bool climbing; // to check if you are currently climbing

    [Header("Wall detection")]
    public float detectionLength;
    public float sphereCastRadius;
    private float wallLookAngle; // current angle

    private RaycastHit frontWallHit; // to store the information of the front wall hit
    private bool wallFront; // to check if there is a wall in front of you


    private void Update()
    {
        WallCheck();
        StateMachine();

        if(climbing) ClimbingMovement();
    }

    private void StateMachine()
    {
        // climbing
        if (wallFront && Input.GetKey(KeyCode.E))
        {
            StartClimbing();
        }

        // not climbing
        else
        {
            if(climbing) StopClimbing();
        }
    }

    private void WallCheck()
    {
        // (starting position, radius, direction, where the information is goin to be stored, length of the spherecast, layer mask)
        wallFront = Physics.SphereCast(transform.position, sphereCastRadius, orientaion.forward, out frontWallHit, detectionLength, whatIsWall);
        // if max climb look angle is for example more than 30 you cant climb it.
        // it's ipmortant if the game has wall climbing because if you don't do the code below you could wall run and climb it at the same time
        // wallLookAngle = Vector3.Angle(orientaion.forward, -frontWallHit.normal);
    }

    private void StartClimbing()
    {
        climbing = true;
    }

    private void ClimbingMovement()
    {
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.z);
    }

    private void StopClimbing()
    {
        climbing = false;
    }
}
