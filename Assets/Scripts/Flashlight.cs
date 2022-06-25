using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Flashlight : MonoBehaviour
{

	public GameObject cam;
	public GameObject flashLight;
	public bool isActive = false;
	void Start()
	{
		cam = GameObject.Find("Player/Bruh/CameraPosition");
		flashLight = GameObject.Find("Player/Flashlight");
		flashLight.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		flashLight.transform.rotation = cam.transform.rotation;
		flashLight.transform.position = cam.transform.position;
		if (Input.GetKeyDown("f"))
		{
			if (!isActive)
			{
				flashLight.SetActive(true);
				isActive = true;
			}
			else
			{
				flashLight.SetActive(false);
				isActive = false;
			}
		}
	}

}
