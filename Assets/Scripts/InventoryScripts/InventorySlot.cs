using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    public Image icon;
    public Button removeButton;

    Item item;
    Fish fish;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;

    }

    public void newFish(Fish aFish)
    {
        fish = aFish;
        icon.sprite = fish.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;

        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.remove(item);
        Inventory.instance.fishRemove(fish);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
