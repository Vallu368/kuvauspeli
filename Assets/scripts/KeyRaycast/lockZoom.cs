using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockZoom : MonoBehaviour
{
    [SerializeField] private Camera mainCam;

    private void Update()
    {

        if (mainCam.fieldOfView > 25)
        {
           if (Input.GetKey(KeyCode.R))
           {
              mainCam.fieldOfView -= 0.2f;
              Debug.Log("zooming in");
           }
                    
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            mainCam.fieldOfView += 35;
            Debug.Log("zooming out");
        }

    }
}
