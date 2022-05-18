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
            if (!isHolding)
            {
            GetComponent<Rigidbody>().isKinematic = true;
            this.transform.parent = GameObject.Find("PickedObjectPos").transform;
                Debug.Log("pickedup");
            isHolding = true;
            }

            else if (isHolding)
            {
            this.transform.parent = null;
            GetComponent<Rigidbody>().isKinematic=false;
                Debug.Log("drop");
            isHolding = false;
            }
        }
    }

    private void Update()
    {
        OnKeyPressed();
    }
}
