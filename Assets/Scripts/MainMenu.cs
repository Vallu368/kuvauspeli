using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    GameObject player;
    PlayerMovement playerMovement;
    PlayerCam cam;

    private void Start()
    {
     player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponentInChildren<PlayerMovement>();
        cam = player.GetComponentInChildren<PlayerCam>();

        playerMovement.canPlayerMove = false;
        cam.canPlayerMove = false;

        Cursor.lockState = CursorLockMode.None;   //cursor ei lukittu
        Cursor.visible = true;                     //cursor n�kyy
    }

    public void StartGame()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;   //cursor lukitto keskelle n�ytt��
        Cursor.visible = false;                     //cursor n�kym�t�n
        playerMovement.canPlayerMove = true;
        cam.canPlayerMove = true;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
