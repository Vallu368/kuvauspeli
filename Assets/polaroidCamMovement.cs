using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polaroidCamMovement : MonoBehaviour
{

    public Transform polaroidPosition;
    public GameObject camRot;

    private void Start()
    {
        camRot = GameObject.Find("Player/CameraHolder/PlayerCam");
    }

    private void Update()
    {
        transform.position = polaroidPosition.position;
        transform.rotation = camRot.transform.rotation;
    }
}
