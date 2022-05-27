using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockZoom : MonoBehaviour
{
    [SerializeField] private GameObject lockCam;
    [SerializeField] private GameObject mainCam;

    //raycast so it only works when clicked on the lock
    //[SerializeField] private int rayLength = 5;
    //[SerializeField] private LayerMask layerMaskInteract;
    //[SerializeField] private string excluseLayername = null;

    //private const string interactableTag = "InteractWithLock";

    private void Update()
    {
        //RaycastHit hit;
        //Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //int mask = 1 << LayerMask.NameToLayer(excluseLayername) | layerMaskInteract.value;
        //if(Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        //{
        //    if (hit.collider.CompareTag(interactableTag))
        //    {
        //    }
        //}
                if (Input.GetKeyDown(KeyCode.E) && Camera.main == enabled)
                {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            mainCam.SetActive(false);
                    lockCam.SetActive(true);
                    Debug.Log("cam switched");
                }
                else if (Input.GetKeyDown(KeyCode.E) && lockCam == true)
                {
                Cursor.lockState = CursorLockMode.Locked;   //cursor lukitto keskelle n?ytt??
                Cursor.visible = false;                     //cursor n?kym?t?n
                mainCam.SetActive(true);
                    lockCam.SetActive(false);
                    Debug.Log("cam switched back");
                }
    }
}
