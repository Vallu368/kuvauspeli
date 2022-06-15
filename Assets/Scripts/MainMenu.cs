using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StarterAssets
{
    public class MainMenu : MonoBehaviour
    {
        FirstPersonController firstPersonController;

        GameObject player;
        PlayerMovement playerMovement;
        PlayerCam cam;
        GameObject bruh;
        GameObject cameraCanvas;
        public GameObject inv;


        [SerializeField] GameObject crosshair;

        private void Start()
        {
            bruh = GameObject.Find("Player/Bruh");
            cameraCanvas = GameObject.Find("Player/CameraCanvas");
            cameraCanvas.SetActive(false);
            inv.SetActive(false);
            bruh.SetActive(false);
         player = GameObject.FindGameObjectWithTag("Player");
            playerMovement = player.GetComponentInChildren<PlayerMovement>();
            cam = player.GetComponentInChildren<PlayerCam>();
        

           // playerMovement.canPlayerMove = false;
            cam.canPlayerMove = false;

            Cursor.lockState = CursorLockMode.None;   //cursor ei lukittu
            Cursor.visible = true;                     //cursor n�kyy

           // firstPersonController = player.GetComponent<FirstPersonController>();
           // firstPersonController.hahmoCanMove = false;
        }

        public void StartGame()
        {
            cameraCanvas.SetActive(true);
            bruh.SetActive(true);
            inv.SetActive(true);
            gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;   //cursor lukitto keskelle n�ytt��
            Cursor.visible = false;                     //cursor n�kym�t�n
           // playerMovement.canPlayerMove = true;
            cam.canPlayerMove = true;
            crosshair.gameObject.SetActive(true);
          //  firstPersonController.hahmoCanMove = true;
        }

        public void QuitGame()
        {
            Application.Quit();
            Debug.Log("Quit game");
        }
        public void SetFullscreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
        }
    }
}
