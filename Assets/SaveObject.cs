using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject
{
    public int completedLevels;
    public List<InventorySlot> inventory;
    public int currentScore;
    public SaveObject()
    {
        completedLevels = PlayerPrefs.GetInt("CompletedLevels", 0);
        currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
    }
    public void InventorySave()
    {
        inventory = NewPlayer.Instance.PlayerInventory.Container;
    }
}
