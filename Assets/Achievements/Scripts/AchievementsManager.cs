using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AchievementsManager : MonoBehaviour
{
    public List<Achievement> Achievements;
    public int integer;
    public float floating;
    private void Awake()
    {
        InitAchievements();
    }
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        DebugAchieve();
        CheckCompltetion();
        if(Input.GetKeyDown(KeyCode.O))
        {
            AchievementUnlocked("First steps1");
        }
    }
    private static AchievementsManager instance;
    public static AchievementsManager Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<AchievementsManager>();
            return instance;
        }
    }
    public void DebugAchieve()
    {
        if (Input.GetKey(KeyCode.K))
        {
            foreach (Achievement achievement in Achievements)
            {
                Debug.Log($"{achievement.Achieved} {achievement.Title}");
            }
        }
        else if(Input.GetKey(KeyCode.L))
        {
            PlayerPrefs.DeleteAll();
        }
    }
    public void AchievementUnlocked(string achievementName)
    {
        Achievement[] achievementsArray = Achievements.ToArray();
        Achievement a = Array.Find(achievementsArray, ach => achievementName == ach.Title);
        a.Achieved = true;
    }
    private void CheckCompltetion()
    {
        if(Achievements == null)
        {
            return;
        }
        foreach(Achievement achievement in Achievements)
        {
            achievement.UpdateCompletion();
        }
    }
    private void InitAchievements()
    {
        if(Achievements != null)
            return;
        Achievements = new List<Achievement>();
        Achievement achievement1 = new Achievement("First steps I", "Travel on your first planet", (object o) => integer >= 100);
        Achievement achievement2 = new Achievement("First steps II", "Travel on your second planet", (object o) => integer >= 150);
        Achievement achievement3 = new Achievement("Killer I", "Kill 10 enemies", (object o) => integer >= 200);
        Achievement achievement4 = new Achievement("Killer II", "Kill 25 enemies", (object o) => integer >= 300);
        //
        Achievement achievement5 = new Achievement("Uppercut I", "Hit enemy with uppercut 5 times", (object o) => integer >= 400);
        Achievement achievement6 = new Achievement("Uppercut II", "Hit enemy with uppercut 10 times", (object o) => integer >= 500);
        Achievement achievement7 = new Achievement("Jumper", "Jump 200 times", (object o) => integer >= 600);
        Achievement achievement8 = new Achievement("Life Support - Online", "Construct Life Support", (object o) => integer >= 700);
        //
        Achievement achievement9 = new Achievement("HyperDrive - online", "Construct HyperDrive", (object o) => integer >= 800);
        Achievement achievement10 = new Achievement("Shields - Online", "Construct Shields", (object o) => integer >= 900);
        Achievement achievement11 = new Achievement("Communication System - Online", "Construct Communication System", (object o) => integer >= 1000);
        Achievement achievement12 = new Achievement("Money maker I", "Collect 200 coins", (object o) => integer >= 1100);
        //
        Achievement achievement13 = new Achievement("Money maker II", "Collect 200 coins", (object o) => integer >= 1200);
        Achievement achievement14 = new Achievement("Almost there", "Complete 3 of 5 missions", (object o) => integer >= 1300);
        Achievement achievement15 = new Achievement("Dead man", "Die 5 times", (object o) => integer >= 1400);
        Achievement achievement16 = new Achievement("Sub-light Engines - Online", "Construct Sub-light engines", (object o) => integer >= 1500);
        ///
        Achievements.Add(achievement1);
        Achievements.Add(achievement2);
        Achievements.Add(achievement3);
        Achievements.Add(achievement4);
        //
        Achievements.Add(achievement5);
        Achievements.Add(achievement6);
        Achievements.Add(achievement7);
        Achievements.Add(achievement8);
        //
        Achievements.Add(achievement9);
        Achievements.Add(achievement10);
        Achievements.Add(achievement11);
        Achievements.Add(achievement12);
        //
        Achievements.Add(achievement13);
        Achievements.Add(achievement14);
        Achievements.Add(achievement15);
        Achievements.Add(achievement16);
    }
}
public class Achievement
{
    public string Title;
    public string Description;
    public Predicate<object> Requirement;
    public bool Achieved;
    public Achievement(string title, string description, Predicate<object> requirement)
    {
        Title = title;
        Description = description;
        Requirement = requirement;
        if(PlayerPrefs.HasKey(title))
        {
            Achieved = Convert.ToBoolean(PlayerPrefs.GetString(title, "FALSE"));
        }
        else
        {
            PlayerPrefs.SetString(title, "FALSE");
        }
    }
    public void UpdateCompletion()
    {
        if(Achieved)
        {
            return;
        }
        if(RequirementsMet())
        {
            EventManager.instance.AchievementCompleted(this);
            Debug.Log($"{Title}: {Description}");
            Achieved = true;
            PlayerPrefs.SetString(Title, "TRUE");
        }
    }
      public bool RequirementsMet()
      { 
        return Requirement.Invoke(null);
      }
}
