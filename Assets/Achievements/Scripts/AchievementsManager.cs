using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AchievementsManager : MonoBehaviour
{
 public List<Achievement> Achievements;
    public int integer;
    public float floating;
    private void Start()
    {
        DontDestroyOnLoad(this);
        InitAchievements();

    }
    private void Update()
    {
        CheckCompltetion();
        if(Input.GetKeyDown(KeyCode.O))
        {
            AchievementUnlocked("First steps1");
        }
    }
    public void AchievementUnlocked(string achievementName)
    {
        Achievement[] achievementsArray = Achievements.ToArray();
        Achievement a = Array.Find(achievementsArray, ach => achievementName == ach.Title);
        a.Achieved = true;
        //bool results = false;
        //if(Achievements == null)
        //    results = false;

        //Achievement[] achievementsArray = Achievements.ToArray();
        //Achievement a = Array.Find(achievementsArray, ach => achievementName == ach.Title);
        //if (a == null)
        //    return false; 

        //results = a.Achieved;

        //return results;
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
        Achievements.Add(new Achievement("First steps1", "Take your first step", (object o) => integer >= 100));
        Achievements.Add(new Achievement("First steps2", "Take your first step2", (object o) => integer >= 150));
        Achievements.Add(new Achievement("First steps3", "Take your first step3", (object o) => integer >= 200));
        Achievements.Add(new Achievement("First steps4", "Take your first step3", (object o) => integer >= 200));
        //
        Achievements.Add(new Achievement("First steps5", "Take your first step", (object o) => integer >= 100));
        Achievements.Add(new Achievement("First steps6", "Take your first step2", (object o) => integer >= 150));
        Achievements.Add(new Achievement("First steps7", "Take your first step3", (object o) => integer >= 200));
        Achievements.Add(new Achievement("First steps8", "Take your first step3", (object o) => integer >= 200));
        //
        Achievements.Add(new Achievement("First steps9", "Take your first step", (object o) => integer >= 100));
        Achievements.Add(new Achievement("First steps10", "Take your first step2", (object o) => integer >= 150));
        Achievements.Add(new Achievement("First steps11", "Take your first step3", (object o) => integer >= 200));
        Achievements.Add(new Achievement("First steps12", "Take your first step3", (object o) => integer >= 200));
        //
        Achievements.Add(new Achievement("First steps13", "Take your first step", (object o) => integer >= 100));
        Achievements.Add(new Achievement("First steps14", "Take your first step2", (object o) => integer >= 150));
        Achievements.Add(new Achievement("First steps15", "Take your first step3", (object o) => integer >= 200));
        Achievements.Add(new Achievement("First steps16", "Take your first step3", (object o) => integer >= 200));
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
        PlayerPrefs.SetString(title, "FALSE");
    }
    public void UpdateCompletion()
    {
        if(Achieved)
        {
            return;
        }
        if(RequirementsMet())
        {
            Debug.Log($"{Title}: {Description}");
            Achieved = true;
        }
    }
    public bool RequirementsMet()
    { 
        return Requirement.Invoke(null);
    }
}
