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
    }
    public event Action<Achievement> onAchievementComplete;
    public void AchievementCompleted(Achievement ach)
    {
        if(onAchievementComplete != null)
        {
            onAchievementComplete(ach);
        }
    }
}
