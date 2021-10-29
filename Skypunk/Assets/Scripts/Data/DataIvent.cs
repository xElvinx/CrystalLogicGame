using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ivent", menuName = "Scriptable objects/Ivent")]
public class DataIvent : ScriptableObject
{
    public string TextHeader;
    public string Text;

    //public string VarA;
    //public string VarB;

    public string VarA;
    public string TextA;
    public DataLoot dataLootA;
    public int countA;

    public string VarB;
    public string TextB;
    public DataLoot dataLootB;
    public int countB;
}
