using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fish")]
public class Fish : ScriptableObject 
{
    public string FishName = "Fish Title";
    public string FishDescription = "Description";
    public float FishWeight = 0.00f;
    public int DefaultValue;
    public int FishValue;
    public bool small, medium, large;
    public Sprite icon = null;
    public bool Legendary= false;

    public virtual void Use()
    {
        if (UIManager.instance.shopwindow == true)
        {
            CurrencyManager.instance.CurrentGold += FishValue;
            Inventory.instance.fishRemove(this);
            
        }
        Debug.Log("Using " + name);
        //if a shop window is open
        //sell the item for the value of the item
        // Remove item from inventory
        // add the sold ammount to currency
    }
}
