using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockControl : MonoBehaviour
{
    private int[] result, correctCombination;

    private bool lockOpen = false;

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
            lockOpen = true;
            Debug.Log("code is correct");
            lockAnim.Play(openLockName);
        }
        else lockOpen = false;
    }

    private void OnDestroy()
    {
        Rotate.Rotated -= CheckResults;
    }
}
