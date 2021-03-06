using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DoorSystem
{


public class NDCtrl : MonoBehaviour
{
    private Animator doorAnim;
    private Animator animator;
        [SerializeField] GameObject forLock;
    private bool doorOpen = false;

    [SerializeField] private int waitTimer = 1;

    [SerializeField] private bool pauseInteraction = false;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
        animator = forLock.GetComponent<Animator>();
    }

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }

        public void PlayAnimation()
    {
        if (!doorOpen && !pauseInteraction)
        {
            doorAnim.Play("doorOpen", 0, 0.0f);
                animator.Play("secondLockAnim", 0, 0.0f);
                doorOpen = true;
                StartCoroutine(PauseDoorInteraction());
            }
        else if (doorOpen && !pauseInteraction) 
        {
            doorAnim.Play("doorClosed", 0, 0.0f);
                animator.Play("secondLockSecondAnim", 0, 0.0f);
                doorOpen = false;
                StartCoroutine(PauseDoorInteraction());
            }
    }
}
}
