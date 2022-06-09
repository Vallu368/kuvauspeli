using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Flashlight : MonoBehaviour
{

    public GameObject cam;
    public GameObject light;
    public bool isActive = false;
    void Start()
    {
        cam = GameObject.Find("Player/Bruh/CameraPosition");
        light = GameObject.Find("Player/Flashlight");
        light.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        light.transform.rotation = cam.transform.rotation;
        light.transform.position = cam.transform.position;
        if (Input.GetKeyDown("f")) 
        {
            if (!isActive)
            {
                light.SetActive(true);
                isActive = true;
            }
            else
            {
                light.SetActive(false);
                isActive = false;
            }
        }
    }

}
