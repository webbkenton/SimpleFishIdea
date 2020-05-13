using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public GameObject informationBox;
    public TMP_Text WeightText;
    public TMP_Text Nametext;
    public TMP_Text Valuetext;
    public TMP_Text Descriptiontext;
    Item item;
    Fish fish;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;

    }
    private void Update()
    {
        //if (fish != null)
        //{ 
        //    InformationUpdate();
        //}
        
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
            InformationReset();
        }
        if (fish != null)
        {
            fish.Use();
            informationBox.SetActive(false);
            InformationReset();
        }
    }

    public void InformationUpdate()
    {
        if (fish != null)
        {
            informationBox.SetActive(true);
            WeightText.text = fish.FishWeight.ToString("F2");
            Nametext.text = fish.FishName;
            Valuetext.text = fish.FishValue.ToString();
            Descriptiontext.text = fish.FishDescription;
        }
    }
    public void InformationReset()
    {
        if (fish != null)
        {
            informationBox.SetActive(false);
            WeightText.text = null;
            Nametext.text = null;
            Valuetext.text = null;
            Descriptiontext.text = null;
        }

    }
}
