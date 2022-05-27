using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyDoorController : MonoBehaviour
    {
        private Animator doorAnim;
        private bool doorOpen = false;

        [Header("Animation names")]
        [SerializeField] private string openAnimationname = "doorOpen";
        [SerializeField] private string closeAnimationname = "doorClosed";

        [SerializeField] private int timeToShowUI = 3;
        [SerializeField] private GameObject showDoorLockedUI = null;

        [SerializeField] private KeyInventory _keyInventory = null;

        [SerializeField] private int waitTimer = 1;

        [SerializeField] private bool pauseInteraction = false;

        private void Awake()
        {
            doorAnim = gameObject.GetComponent<Animator>();
        }

        private IEnumerator PauseDoorInteraction()
        {
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
        }

        public void PlayAnimation()
        {
            if (_keyInventory.hasKey) //if we have the key
            {
                if (!doorOpen && !pauseInteraction) //if door is closed and we can interact with it
                {
                    doorAnim.Play(openAnimationname, 0, 0.0f);
                    doorOpen = true;
                    StartCoroutine(PauseDoorInteraction());
                }
                else if (doorOpen && !pauseInteraction) //if door is open and we can interact with it
                {
                    doorAnim.Play(closeAnimationname, 0, 0.0f);
                    doorOpen = false;
                    StartCoroutine(PauseDoorInteraction());
                }
            }

            else
            {
                StartCoroutine(ShowDoorLocked());
            }
        }

        IEnumerator ShowDoorLocked()
        {
            showDoorLockedUI.SetActive(true);
            yield return new WaitForSeconds(timeToShowUI);
            showDoorLockedUI.SetActive(false);
        }

    }
}
