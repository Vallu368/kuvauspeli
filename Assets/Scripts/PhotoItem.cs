using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new Photo Item", menuName = "Photo Item")]

public class PhotoItem : ItemClass
{
    public override ItemClass GetItem() { return this; }
    public override PhotoItem GetPhotoItem() { return this; }
}
