using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public TMP_Text Nametext;
    public TMP_Text Valuetext;
    public TMP_Text Descriptiontext;
    public Image icon;
    public Button removeButton;
    public GameObject informationBox;
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
        //Nametext.text = fish.FishName;
        //Valuetext.text = fish.FishValue.ToString();
        //Descriptiontext.text = fish.FishDescription;

    }

    public void ClearSlot()
    {
        item = null;
        fish = null;

        icon.sprite = null;
        icon.enabled = false;

        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.remove(item);
        Inventory.instance.fishRemove(fish);
        ClearSlot();
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
        if (fish != null)
        {
            fish.Use();
        }
    }

    private void OnMouseOver()
    {
        //Nametext.text = fish.FishName;
        //Valuetext.text = fish.FishValue.ToString();
        //Descriptiontext.text = fish.FishDescription;
        informationBox.SetActive(true);
    }
}
