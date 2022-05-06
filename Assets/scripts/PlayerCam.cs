using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float senX;
    public float senY;

    public Transform orientation;

    public float xRotation;
    public float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   //cursor lukitto keskelle näyttöä
        Cursor.visible = false;                     //cursor näkymätön
    }

    private void Update()
    {
        // hiiren input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senY;

        // tällä unityn pitäs osata rotate systeemiä
        yRotation += mouseX;
        xRotation -= mouseY;

        // voi kattoo ylös/alas vain 90 astetta
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // jotta roate toimii kamerassa
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        // jotta pelaaja kääntyy kameran mukana
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
