using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    private float xRotation;
    private float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   //cursor lukitto keskelle n�ytt��
        Cursor.visible = false;                     //cursor n�kym�t�n
    }

    private void Update()
    {
        // hiiren input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        // t�ll� unityn pit�s osata rotate systeemi�
        yRotation += mouseX;
        xRotation -= mouseY;

        // voi kattoo yl�s/alas vain 90 astetta
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // jotta roate toimii kamerassa
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        // jotta pelaaja k��ntyy kameran mukana
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
