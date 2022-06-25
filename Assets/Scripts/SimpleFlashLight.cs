using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SimpleFlashLight : MonoBehaviour
{
	[SerializeField] Light flashLight;
	void Start()
	{
		flashLight.enabled = false;
	}

	void Update()
	{
		if (Input.GetKeyDown("f"))
		{
			flashLight.enabled = !flashLight.enabled;
		}
	}

}
