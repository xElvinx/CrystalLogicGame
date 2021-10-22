using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Loot", menuName = "Scriptable objects/Loot")]
public class DataLoot : ScriptableObject
{
    public Sprite img;
    public string Name;
}
