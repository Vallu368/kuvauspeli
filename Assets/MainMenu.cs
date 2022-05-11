using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    GameObject bruh;
    PlayerMovement playerMovement;
    PlayerCam cam;

    private void Start()
    {
        bruh = GameObject.FindGameObjectWithTag("Player");
        playerMovement = bruh.GetComponent<PlayerMovement>();
        cam = bruh.GetComponentInChildren<PlayerCam>();

        playerMovement.canPlayerMove = false;
        cam.canPlayerMove = false;

        Cursor.lockState = CursorLockMode.None;   //cursor ei lukittu
        Cursor.visible = true;                     //cursor näkyy
    }

    public void StartGame()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;   //cursor lukitto keskelle näyttöä
        Cursor.visible = false;                     //cursor näkymätön
        playerMovement.canPlayerMove = true;
        cam.canPlayerMove = true;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
