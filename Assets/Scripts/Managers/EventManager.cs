using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        Screen.SetResolution(1920,1080, true);
    }
    public event Action<Achievement> onAchievementComplete;
    public event Action<int> onPointsAdded;
    public void AchievementCompleted(Achievement ach)
    {
        if(onAchievementComplete != null)
        {
            onAchievementComplete(ach);
        }
    }
    public void PointsAdded(int amount)
    {
        if(onPointsAdded != null)
        {
            onPointsAdded(amount);
        }
    }
}
