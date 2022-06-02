using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crystal Item", menuName = "Inventory System/Items/Coin")]
public class Coin : Item
{
    public float recieveIfSold;
    public void Awake()
    {
        type = ItemType.Coin;
    }
}
