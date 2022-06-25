using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideFinalObjective : MonoBehaviour
{
	[SerializeField] private InventoryScript inv;
	private BoxCollider box;
	public int PicturesNeededToUse;
	void Start()
	{
		//inv = GameObject.Find("Player/Bruh").GetComponent<InventoryScript>(); //using serialized reference in favor of GameObject.Find
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
