using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
	public bool isGamePaused = false;

	[SerializeField] GameObject pauseMenu;

	[SerializeField] GameObject player;
	PlayerMovement playerMovement;
	PlayerCam cam;

	private void Start()
	{
		//player = GameObject.FindGameObjectWithTag("Player"); //using serialized reference in favor of GameObject.Find
		playerMovement = player.GetComponentInChildren<PlayerMovement>();
		cam = player.GetComponentInChildren<PlayerCam>();

		playerMovement.canPlayerMove = false;
		cam.canPlayerMove = false;

		Cursor.lockState = CursorLockMode.None;   //cursor ei lukittu
		Cursor.visible = true;                     //cursor n�kyy
	}

	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			if (isGamePaused)
			{
				ResumeGame();
			}
			else PauseGame();
		}
	}

	void ResumeGame()
	{
		isGamePaused = false;
		pauseMenu.SetActive(false);
	}

	void PauseGame()
	{
		isGamePaused = true;
		pauseMenu.SetActive(true);
	}
}
