using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpening : MonoBehaviour
{
    private InventoryScript inv;
    public int PicturesNeededToUse;
    private Animator leftAnimator;
    private Animator rightAnimator;
    [SerializeField] GameObject forLeftAnimator;
    [SerializeField] GameObject forRightAnimator;

    private void Awake()
    {
        leftAnimator = forLeftAnimator.GetComponent<Animator>();
        rightAnimator = forRightAnimator.GetComponent<Animator>();
    }

    void Start()
    {
        inv = GameObject.Find("Player/Bruh").GetComponent<InventoryScript>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Test")
        {
            if (inv.picturesTaken >= PicturesNeededToUse)
            {
                leftAnimator.Play("vasenPorttiAuki", 0, 0.0f);
                rightAnimator.Play("oikeePorttiAuki", 0, 0.0f);
            }
            else Debug.Log("not enough pics");
        }
    }


}
