using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Part Item", menuName = "Inventory System/Items/Medkit")]
public class Medkit : Item
{
    private void Awake()
    {
        type = ItemType.Medkit;
    }
}
