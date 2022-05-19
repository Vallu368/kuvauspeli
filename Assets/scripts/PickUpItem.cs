using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, item, fpsCam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private void Start()
    {
        //setup item the right way
        if (!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    private void Update()
    {
        //check if player is close enough and E is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            PickUp();
            Debug.Log("picking up");
        }
        else if (equipped && Input.GetKeyDown(KeyCode.E))
        {
            Drop();
            //force to throw the gun. impulse bc its one time
            rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
            rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);
            Debug.Log("dropping");
        }
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //make item a child of the camera and move it to default position
        transform.SetParent(item);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //make rb kinematic so it doesnt move anymore and boxcollider a trigger
        rb.isKinematic = true;
        //rb.useGravity = false;
        coll.isTrigger = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        //set parent to null
        transform.SetParent(null);

        //gun carries momentum of player
        //rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //make rb not kinematic so it moves and boxcollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;
    }
}
