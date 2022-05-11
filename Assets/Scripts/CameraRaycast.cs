using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    private Ray ray;
    public TakePhoto takePhoto;

    public float sphereRadius;
    public float distance;
    public LayerMask layerMask;
    private Vector3 origin;
    private Vector3 direction;


    private void Start()
    {

    }
    private void Update()
    {
        origin = transform.position;
        direction = transform.forward;
        RaycastHit hit;
        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, distance, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            if (hit.collider.tag == "TEST TAG")
            {
                if (takePhoto.cameraMode && Input.GetMouseButtonDown(0))
                {
                    hit.collider.GetComponent<GhostScript>().isGhostActive = true;
                }
            }
        }

    }
}