
using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Inventory/Item" )]
public class Item : ScriptableObject 
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    
    
    public virtual void Use()
    {
        if (UIManager.instance.Shop == true)
        {
            
        }
        Debug.Log("Using " + name);
        //if a shop window is open
        //sell the item for the value of the item
        // Remove item from inventory
        // add the sold ammount to currency
    }

}
