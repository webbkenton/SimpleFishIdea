using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fish")]
public class Fish : ScriptableObject 
{
    public string FishName = "Fish Title";
    public string FishDescription = "Description";
    public float FishWeight = 0.00f;
    public bool small, medium, large;
    public Sprite icon = null;
    public bool Legendary= false;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }
}
