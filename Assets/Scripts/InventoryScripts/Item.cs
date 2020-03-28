
using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Inventory/Item" )]
public class Item : ScriptableObject 
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    
    
    public virtual void Use()
    {
        //Use the item
        //Something Might Happen
        Debug.Log("Using " + name);
    }

}
