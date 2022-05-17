using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public TakePhoto takePhoto;

    public List<PhotoItem> photos;
    public List<Image> images;
    public PhotoItem item;
    public GameObject inventoryPanel;
    public bool inventoryOpen;
    public int i;
    void Start()
    {
        inventoryPanel.SetActive(false);
        inventoryOpen = false;
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

            }
            else
            {
                inventoryPanel.SetActive(false);
                inventoryOpen = false;
            }
        }
        for (int i = 0; i < photos.Count; i++)
        images[i].sprite = photos[i].itemSprite;
        
    }

    public void AddImageToInventory(int id, Sprite sprite)
    {
        photos[id].itemSprite = sprite;
    }
}
