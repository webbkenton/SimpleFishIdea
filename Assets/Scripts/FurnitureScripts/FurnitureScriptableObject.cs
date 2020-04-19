using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Furniture")]
public class FurnitureScriptableObject : ScriptableObject
{
    public string FurnitureName = "Furniture Name";
    public Sprite Sprite = null;
    
}
