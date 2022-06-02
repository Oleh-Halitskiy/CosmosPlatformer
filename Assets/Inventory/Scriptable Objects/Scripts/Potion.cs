using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Part Item", menuName = "Inventory System/Items/Potion")]
public class Potion : Item
{
    private void Awake()
    {
        type = ItemType.Potion;
    }
}

