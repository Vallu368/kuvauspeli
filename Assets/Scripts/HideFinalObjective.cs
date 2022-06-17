using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideFinalObjective : MonoBehaviour
{
    private InventoryScript inv;
    private BoxCollider box;
    public int PicturesNeededToUse;
    void Start()
    {
        inv = GameObject.Find("Player/Bruh").GetComponent<InventoryScript>();
        box = this.gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inv.picturesTaken >= PicturesNeededToUse)
        {
            box.enabled = true;
        }
        else box.enabled = false;
    }
}
