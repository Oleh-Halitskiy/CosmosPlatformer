using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement System/Achievement")]
public class AchievementPanel : ScriptableObject
{
    public Sprite Image;
    public string Title;
    public string Description;
    public bool Completed;
}
