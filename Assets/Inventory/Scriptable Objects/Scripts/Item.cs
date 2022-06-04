using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Crystal,
    Parts,
    Medkit,
    Potion,
    Coin

}
public abstract class Item : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(15,20)]
    public string description;

}
