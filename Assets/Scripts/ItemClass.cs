using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemClass : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public string description;

    public abstract ItemClass GetItem();

    public abstract PhotoItem GetPhotoItem();

}
