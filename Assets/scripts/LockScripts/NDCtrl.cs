using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NDCtrl : MonoBehaviour
{
    private Animator doorAnim;
    private bool doorOpen = false;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            doorAnim.Play("doorOpen", 0, 0.0f);
            doorOpen = true;
        }
        else if (doorOpen) 
        {
            doorAnim.Play("doorClosed", 0, 0.0f);
            doorOpen = false;
        }
    }
}
