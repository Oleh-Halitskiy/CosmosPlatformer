using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
   public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(Item item, int amount)
    {
            bool hasItem = false;
            for (int i = 0; i < Container.Count; i++)
            {
                if (Container[i].item == item)
                {
                    Container[i].AddAmount(amount);
                    Debug.Log("you had this item");
                    hasItem = true;
                    break;
                }
            }
            if(!hasItem)
            {
                 Debug.Log("new slot cretaed");
                 Container.Add(new InventorySlot(item, amount));
            }
    }
}
[System.Serializable]
public class InventorySlot
{
    public Item item;
    public int amount;
    public InventorySlot(Item item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}
