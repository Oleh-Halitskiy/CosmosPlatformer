using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Part Item", menuName = "Inventory System/Items/Shuttle Part")]
public class ShuttlePart : Item
{
    public void Awake()
    {
        type = ItemType.Parts;
    }
}
