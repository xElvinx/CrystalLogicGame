using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card", menuName = "Scriptable objects/Card")]
public class DataCard : ScriptableObject
{
    public enum classCard {Enemy, Fuel, Search};
    public classCard card;
    
    public int minDamage;
    public int maxDamage;
    public string IventText;
    public string IventHeader;
}
