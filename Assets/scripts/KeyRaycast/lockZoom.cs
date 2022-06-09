using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class lockZoom : MonoBehaviour
{
    //https://www.youtube.com/watch?v=w0AOGeqOnFY&list=LL&index=282 coconut

    //[SerializeField] private Camera mainCam;
    [SerializeField] private GameObject maxZoomText;

    private float scrollSpeed = 50;

    public CinemachineVirtualCamera virtualCamera;

    private void Update()
    {
        if (virtualCamera.m_Lens.FieldOfView <= 45)
        {
            virtualCamera.m_Lens.FieldOfView -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        }
        else virtualCamera.m_Lens.FieldOfView = 45;

        if (virtualCamera.m_Lens.FieldOfView >= 20)
        {
            virtualCamera.m_Lens.FieldOfView -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        }
        else virtualCamera.m_Lens.FieldOfView = 20;


        //if (mainCam.fieldOfView < 60)
        //{
        //    if (Input.GetKey(KeyCode.T))
        //    {
        //        mainCam.fieldOfView += 0.2f;
        //        Debug.Log("zooming out");
        //    }
        //}

        if(virtualCamera.m_Lens.FieldOfView <= 33)
        {
            maxZoomText.SetActive(true);
        }
        else maxZoomText.SetActive(false);

    }
}
