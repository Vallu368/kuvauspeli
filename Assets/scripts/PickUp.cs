using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform thePos;
    public bool isHolding = false;

    void OnKeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isHolding = true;
            GetComponent<Rigidbody>().isKinematic = true;
            this.transform.parent = GameObject.Find("PickedObjectPos").transform;
        }

        if(Input.GetKeyUp(KeyCode.E))
        {
            isHolding = false;
            this.transform.parent = null;
            GetComponent<Rigidbody>().isKinematic=false;
        }
    }

    private void Update()
    {
        OnKeyPressed();
    }
}
