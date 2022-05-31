using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockZoom : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject maxZoomText;

    private float scrollSpeed = 50;

    private void Update()
    {

        if (mainCam.fieldOfView <= 60)
        {
            mainCam.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        }
        else mainCam.fieldOfView = 60;

        if (mainCam.fieldOfView >= 25)
        {
            mainCam.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        }
        else mainCam.fieldOfView = 25;


        //if (mainCam.fieldOfView < 60)
        //{
        //    if (Input.GetKey(KeyCode.T))
        //    {
        //        mainCam.fieldOfView += 0.2f;
        //        Debug.Log("zooming out");
        //    }
        //}

        if(mainCam.fieldOfView <= 33)
        {
            maxZoomText.SetActive(true);
        }
        else maxZoomText.SetActive(false);

    }
}
