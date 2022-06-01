using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crystal Item", menuName = "Inventory System/Items/Crystal")]
public class Crystal : Item
{
    public float recieveIfSold;
    public void Awake()
    {
        type = ItemType.Crystal;
    }
}
