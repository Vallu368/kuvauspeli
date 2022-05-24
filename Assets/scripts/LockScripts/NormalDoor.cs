using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DoorSystem
{

public class NormalDoor : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excluseLayername = null;

    private NDCtrl doorController;

    [SerializeField] private KeyCode openDoorKey = KeyCode.E;
    private bool doOnce;

    private const string interactableTag = "InteractWithDoor";

        private void Update()
        {
            
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excluseLayername) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                if (!doOnce)
                {
                    doorController = hit.collider.gameObject.GetComponent<NDCtrl>();
                }

                doOnce = true;

                if (Input.GetKeyDown(openDoorKey))
                {
                    doorController.PlayAnimation();
                }
            }
        }
        }



}
}
