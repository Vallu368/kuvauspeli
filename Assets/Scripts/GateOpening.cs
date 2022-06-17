using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpening : MonoBehaviour
{
    private InventoryScript inv;
    public int PicturesNeededToUse;
    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.Find("Player/Bruh").GetComponent<InventoryScript>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Test")
        {
            Debug.Log("boooop");
        }
    }


}
