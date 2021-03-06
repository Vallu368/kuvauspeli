using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
	public Transform thePos;
	public bool isHolding = false;

	void OnKeyPressed()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (!isHolding)
			{
				GetComponent<Rigidbody>().useGravity = false;
				this.transform.parent = GameObject.Find("PickedObjectPos").transform;
				GetComponent<Rigidbody>().freezeRotation = true;
				Debug.Log("pickedup");
				isHolding = true;
			}

			else if (isHolding)
			{
				this.transform.parent = null;
				GetComponent<Rigidbody>().useGravity = true;
				GetComponent<Rigidbody>().freezeRotation = false;
				Debug.Log("drop");
				isHolding = false;
			}
		}
	}

	private void Update()
	{
		OnKeyPressed();
	}
}
