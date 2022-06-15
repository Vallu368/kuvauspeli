using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public TakePhoto takePhoto;

    public List<Image> images;
    public GameObject tutorialText;
    public List<GameObject> inventoryPhotos;
    public GameObject inventoryPanel;
    public bool inventoryOpen;
    public int i;
    public int picturesTaken;

    GameObject fCam;

    GameObject player;
    PlayerCam cam;
    TakePhoto photo;
    void Start()
    {
        fCam = GameObject.Find("Player/FollowCam");
        inventoryPanel.SetActive(false);
        inventoryOpen = false;
        tutorialText = GameObject.Find("Player/CameraCanvas/TutorialText");

        player = GameObject.FindGameObjectWithTag("Player");
        cam = player.GetComponentInChildren<PlayerCam>();
        photo = player.GetComponentInChildren<TakePhoto>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!photo.cameraMode && Input.GetKeyDown("i"))
        {
            if (inventoryOpen == false)
            {
                fCam.SetActive(false);
                tutorialText.SetActive(false);
                inventoryPanel.SetActive(true);
                inventoryOpen = true;
                Cursor.lockState = CursorLockMode.None;   //cursor ei lukittu
                Cursor.visible = true;  
                cam.canPlayerMove = false;
                photo.enabled = false;
                
                

            }
            else
            {
                fCam.SetActive(true);
                inventoryPanel.SetActive(false);
                inventoryOpen = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                cam.canPlayerMove = true;
                photo.enabled = true;
            }
        }
        
    }

    public void AddImageToInventory(int id, Sprite sprite)
    {
        images[id].sprite = sprite;
        inventoryPhotos[id].SetActive(true);
        
    }
}
