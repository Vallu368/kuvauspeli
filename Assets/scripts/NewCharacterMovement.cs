using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCharacterMovement : MonoBehaviour
{
    public float playerSpeed;
    public float rotationSpeed;

    PlayerCam cam;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        cam = characterController.GetComponent<PlayerCam>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticallInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticallInput);
        float magnitude = Mathf.Clamp01(moveDirection.magnitude) * playerSpeed;
        moveDirection.Normalize();

        characterController.SimpleMove(moveDirection * magnitude);

        if(moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
