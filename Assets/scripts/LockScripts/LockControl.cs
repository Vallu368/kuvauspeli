using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DoorSystem
{

public class LockControl : MonoBehaviour
{
    private int[] result, correctCombination;
        private NormalDoor normalDoorScript;
    private Animator lockAnim;
    [SerializeField] private string openLockName = "lockOpen";

    private void Awake()
    {
        lockAnim = gameObject.GetComponentInParent<Animator>();
    }

    private void Start()
    {
        result = new int[] {0, 0, 0};
        correctCombination = new int[] { 1, 2, 3 };
        Rotate.Rotated += CheckResults;

        normalDoorScript = GameObject.Find("PlayerCam").GetComponent<NormalDoor>();
           normalDoorScript.enabled = false;
    }

    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "FirstGear":
                result[0] = number;
                break;

            case "SecondGear":
                result[1] = number;
                break;

            case "ThirdGear":
                result[2] = number;
                break;
        }

        if(result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2])
        {
            Debug.Log("code is correct");
            lockAnim.Play(openLockName);
              
                normalDoorScript.enabled = true;
            }
    }

    private void OnDestroy()
    {
        Rotate.Rotated -= CheckResults;
    }
}
}
