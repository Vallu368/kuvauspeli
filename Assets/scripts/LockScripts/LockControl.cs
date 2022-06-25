using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DoorSystem
{

	public class LockControl : MonoBehaviour
	{
		private int[] result, correctCombination;
		[SerializeField] private NormalDoor normalDoorScript;
		private Animator lockAnim;
		[SerializeField] private string openLockName = "lockOpen";

		[SerializeField] private GameObject lockObject;

		private void Awake()
		{
			lockAnim = gameObject.GetComponentInParent<Animator>();
		}

		private void Start()
		{
			result = new int[] { 0, 0, 0 };
			correctCombination = new int[] { 8, 5, 8 };
			Rotate.Rotated += CheckResults;

			//lockObject = GameObject.Find("Combination_Padlock"); //using serialized reference in favor of GameObject.Find

			//normalDoorScript = GameObject.Find("PlayerCam").GetComponent<NormalDoor>(); //using serialized reference in favor of GameObject.Find
			normalDoorScript.enabled = false;
		}

		private void CheckResults(string wheelName, int number)
		{
			switch (wheelName)
			{
				case "FirstGear":
					result[0] = number;
					break;

				case "SecondGear":
					result[1] = number;
					break;

				case "ThirdGear":
					result[2] = number;
					break;
			}

			if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2])
			{
				Debug.Log("code is correct");
				lockAnim.Play(openLockName);

				StartCoroutine("Unlock");

				normalDoorScript.enabled = true;
			}
		}

		private IEnumerator Unlock()
		{
			yield return new WaitForSeconds(1.5f);
			lockObject.SetActive(false);
		}

		private void OnDestroy()
		{
			Rotate.Rotated -= CheckResults;
		}
	}
}
