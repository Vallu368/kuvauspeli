using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatLevelSkip : MonoBehaviour
{
	KeyCode skipkey = KeyCode.L;
	float cheatUITimer = 5;
	void OnGUI()
	{
		if(cheatUITimer>0f)
			GUI.Label(new Rect(10, 10, 200, 20), "Skip scene with "+skipkey+" key");
	}

	void Update()
	{
		if(cheatUITimer>0f)
			cheatUITimer-=Time.deltaTime;

		if(Input.GetKeyDown(skipkey))
		{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
