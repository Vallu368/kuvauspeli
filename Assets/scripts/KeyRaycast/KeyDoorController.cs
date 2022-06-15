using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyDoorController : MonoBehaviour
    {
        private Animator doorAnim;
        private Animator animator;
        private Animator schoolAnimator;
        [SerializeField] GameObject forRandomLock;
        [SerializeField] GameObject forSchoolLock;
        [SerializeField] GameObject schoolLock;
        [SerializeField] GameObject randomLock;
        [SerializeField] private KeyItemController _keyItemController;

        private bool doorOpen = false;

        [Header("Animation names")]
        [SerializeField] private string openAnimationname = "doorOpen";
        [SerializeField] private string closeAnimationname = "doorClosed";

        //[SerializeField] private int timeToShowUI = 3;
        //[SerializeField] private GameObject showDoorLockedUI = null;

        [SerializeField] private KeyInventory _keyInventory = null;

        [SerializeField] private int waitTimer = 1;

        [SerializeField] private bool pauseInteraction = false;

        private void Awake()
        {
            doorAnim = gameObject.GetComponent<Animator>();
            animator = forRandomLock.GetComponent<Animator>();
            schoolAnimator = forSchoolLock.GetComponent<Animator>();
        }

        private IEnumerator PauseDoorInteraction()
        {
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
        }

        public void PlayAnimation()
        {
            if (_keyInventory.hasGreenKey && _keyItemController.purpleDoor) //if we have the GREEN key
            {
                Debug.Log("green key and purple door");
                randomLock.SetActive(false);
                if (!doorOpen && !pauseInteraction) //if door is closed and we can interact with it
                {
                    doorAnim.Play(openAnimationname, 0, 0.0f);
                    animator.Play("randomTaloLockSystem", 0, 0.0f);
                    doorOpen = true;
                    StartCoroutine(PauseDoorInteraction());
                }
                else if (doorOpen && !pauseInteraction) //if door is open and we can interact with it
                {
                    doorAnim.Play(closeAnimationname, 0, 0.0f);
                    animator.Play("randomTaloClosing", 0, 0.0f);
                    doorOpen = false;
                    StartCoroutine(PauseDoorInteraction());
                }
            }

            else if(_keyInventory.hasRedKey && _keyItemController.blueDoor)
            {
                Debug.Log("red key and blue door");
                schoolLock.SetActive(false);
                if (!doorOpen && !pauseInteraction) //if door is closed and we can interact with it
                {
                    doorAnim.Play(openAnimationname, 0, 0.0f);
                    schoolAnimator.Play("schoolLockAnim", 0, 0.0f);
                    doorOpen = true;
                    StartCoroutine(PauseDoorInteraction());
                }
                else if (doorOpen && !pauseInteraction) //if door is open and we can interact with it
                {
                    doorAnim.Play(closeAnimationname, 0, 0.0f);
                    schoolAnimator.Play("schoolClosingAnim", 0, 0.0f);
                    doorOpen = false;
                    StartCoroutine(PauseDoorInteraction());
                }
            }

            //else
            //{
            //    StartCoroutine(ShowDoorLocked());
            //}
        }

        //IEnumerator ShowDoorLocked()
        //{
        //    showDoorLockedUI.SetActive(true);
        //    yield return new WaitForSeconds(timeToShowUI);
        //    showDoorLockedUI.SetActive(false);
        //}

    }
}
