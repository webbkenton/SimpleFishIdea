using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FurnitureScriptableObjectList")]
public class FurnitureList : ScriptableObject
{
    public int RandomSpace = 10;
    public List<FurnitureScriptableObject> ShopList = new List<FurnitureScriptableObject>();
    public List<FurnitureScriptableObject> RandomList = new List<FurnitureScriptableObject>();
    public List<FurnitureScriptableObject> DuplicateList =  new List<FurnitureScriptableObject>();
    public void RandomListGenerator()
    {
        for (int i = 0; i < DuplicateList.Count; i++)
        {
            int oldi = i;
            i = Random.Range(0, DuplicateList.Count);
            if (RandomList.Count < RandomSpace)
            {
                RandomList.Add(DuplicateList[i]);
                DuplicateList.Remove(DuplicateList[i]);
                i = oldi;
            }
            if (DuplicateList.Count == RandomList.Count)
            {
                Duplicate();
            }
        }
    }
    public void Duplicate()
    {
        for (int i = 0; i < ShopList.Count; i++)
        {
            DuplicateList.Add(ShopList[i]);
        }
    }
}
