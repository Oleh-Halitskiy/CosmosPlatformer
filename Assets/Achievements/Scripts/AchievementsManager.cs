using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AchievementsManager : MonoBehaviour
{

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
    }
    public void UpdateCompleted()
    {
        if(Achieved)
        {

        }
    }
    public bool Reqirmentsmet()
    {
        throw new NotImplementedException();
    }
}
