using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;

    public GameObject inventoryUI;
    public GameObject InventoryCanvas;

    public Transform itemsParent;

    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        InventoryCanvas.SetActive(false);
        InventoryCanvas.SetActive(true);
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
        
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {

            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
                //slots[i].newFish(inventory.fishs[i]);
                //slots[i].NewFurniture(inventory.Furniture[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.fishs.Count)
            {
                slots[i].newFish(inventory.fishs[i]);
            }

        }
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.Furniture.Count)
            {
                slots[i].NewFurniture(inventory.Furniture[i]);
            }

        }
        
    }
}
