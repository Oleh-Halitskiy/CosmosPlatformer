using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject
{
    public int completedLevels;
    public int test = 1;
    public List<InventorySlot> inventory;
    public List<Achievement> achievements;
    public SaveObject()
    {
        completedLevels = PlayerPrefs.GetInt("CompletedLevels", 0);
    }
    public void InventorySave()
    {
        inventory = NewPlayer.Instance.PlayerInventory.Container;
    }
    public void AchievementsSave()
    {
        achievements = AchievementsManager.Instance.Achievements;
    }
}
