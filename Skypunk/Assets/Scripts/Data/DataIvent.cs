using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ivent", menuName = "Scriptable objects/Ivent")]
public class DataIvent : ScriptableObject
{
    public string TextHeader;
    public string Text;

    public string VarA;
    public string VarB;
}
