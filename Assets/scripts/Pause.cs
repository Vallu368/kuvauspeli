using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public static bool isGamePaused = false;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            } else PauseGame();
        } 
    }

    public void ResumeGame()
    {
        isGamePaused = false;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;   //cursor lukitto keskelle n?ytt??
        Cursor.visible = false;                     //cursor n?kym?t?n
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        isGamePaused = true;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;   //cursor ei lukittu
        Cursor.visible = true;                     //cursor n?kyy
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quit");
    }
}
