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
                    hasItem = true;
                    break;
                }
            }
            if(!hasItem)
            {
                 Container.Add(new InventorySlot(item, amount));
                 if(item.description == "SLE")
                 {
                    PlayerPrefs.SetInt("SLE", 1);
                 }
                 else if(item.description == "CS")
                 {
                    PlayerPrefs.SetInt("CS", 1);
                 }
                 else if(item.description == "S")
                 {
                    PlayerPrefs.SetInt("S", 1);
                 }
                 else if (item.description == "LS")
                 {
                    PlayerPrefs.SetInt("LS", 1);
                 }
            }
    }
    public void RemoveItem(Item item, int amount)
    {
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == item)
            {
                Container[i].RemoveAmount(amount);
                break;
            }
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
    public void RemoveAmount(int value)
    {
        if (amount > 0)
        {
            amount -= value;
        }
    }
}
