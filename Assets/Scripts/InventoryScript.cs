using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public TakePhoto takePhoto;

    public List<Image> images;
    public GameObject inventoryPanel;
    public bool inventoryOpen;
    public int i;

    GameObject player;
    PlayerMovement playerMovement;
    PlayerCam cam;
    void Start()
    {
        inventoryPanel.SetActive(false);
        inventoryOpen = false;

        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponentInChildren<PlayerMovement>();
        cam = player.GetComponentInChildren<PlayerCam>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("i"))
        {
            if (inventoryOpen == false)
            {
                inventoryPanel.SetActive(true);
                inventoryOpen = true;
                Cursor.lockState = CursorLockMode.None;   //cursor ei lukittu
                Cursor.visible = true;
                playerMovement.canPlayerMove = false;
                cam.canPlayerMove = false;
                playerMovement.enabled = false;
                
                

            }
            else
            {
                inventoryPanel.SetActive(false);
                inventoryOpen = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                playerMovement.canPlayerMove = true;
                cam.canPlayerMove = true;
                playerMovement.enabled = true;
            }
        }
        //for (int i = 0; i < photos.Count; i++)
        //images[i].sprite = photos[i].itemSprite;
        
    }

    public void AddImageToInventory(int id, Sprite sprite)
    {
        images[id].sprite = sprite; 
        
    }
}
