using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public TakePhoto takePhoto;

    public List<PhotoItem> photos;
    public Image img1;
    public Image img2;
    public PhotoItem item;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        img1.sprite = photos[0].itemSprite;
        img2.sprite = photos[1].itemSprite;
    }

    public void AddImageToInventory(int id, Sprite sprite)
    {
        photos[id].itemSprite = sprite;
    }
}
