using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FurnitureShopWindow : MonoBehaviour
{
    public int ShopSpace = 10;
    public FurnitureList GVFurnitureList;
    public List<FurnitureScriptableObject> ShopItems = new List<FurnitureScriptableObject>();
    public FurnitureShopSlot[] SlotChild;
    // Start is called before the first frame update
    void Start()
    {
        SlotChild = GetComponentsInChildren<FurnitureShopSlot>();
        GVFurnitureList.Duplicate();
        GVFurnitureList.RandomListGenerator();

        for (int i = 0; i < GVFurnitureList.RandomList.Count; i++)
        {
            if (ShopItems.Count <= ShopSpace)
            {
                ShopItems.Add(GVFurnitureList.RandomList[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < SlotChild.Length; i++)
        {
            SlotChild[i].Furniture = ShopItems[i];
            SlotChild[i].NameText.text = ShopItems[i].FurnitureName;
            SlotChild[i].StyleText.text = ShopItems[i].Style;
            SlotChild[i].CostText.text = ShopItems[i].PurchaseValue.ToString();
            SlotChild[i].Icon = ShopItems[i].sprite;
        }
    }
}
