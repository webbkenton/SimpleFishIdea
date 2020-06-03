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
    public FurnitureShopSlot[] BuySlotChild;
    public FurnitureShopSlot[] SoldSlotChild;
    public List<FurnitureScriptableObject> SoldItems = new List<FurnitureScriptableObject>();
    public GameObject BuyTab;
    public GameObject SellTab;
    // Start is called before the first frame update
    void Start()
    {
        BuySlotChild = BuyTab.GetComponentsInChildren<FurnitureShopSlot>();
        SoldSlotChild = SellTab.GetComponentsInChildren<FurnitureShopSlot>();
        GVFurnitureList.Duplicate();
        GVFurnitureList.RandomListGenerator();
        BuyTab.SetActive(true);

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
        if (Input.GetButtonDown("CloseShop"))
        {
            UIManager.instance.Shop.SetActive(!UIManager.instance.Shop.activeSelf);
        }
        for (int i = 0; i < BuySlotChild.Length; i++)
        {
            BuySlotChild[i].Furniture = ShopItems[i];
            BuySlotChild[i].NameText.text = ShopItems[i].FurnitureName;
            BuySlotChild[i].StyleText.text = ShopItems[i].Style;
            BuySlotChild[i].CostText.text = ShopItems[i].PurchaseValue.ToString();
            BuySlotChild[i].Icon = ShopItems[i].sprite;
        }
        if (SoldItems.Count != 0)
        {
            for (int i = 0; i < SoldItems.Count; i++)
            {
                if (SoldItems[i] == null)
                {
                    SoldSlotChild[i].Furniture = null;
                    SoldSlotChild[i].NameText.text = null;
                    SoldSlotChild[i].StyleText.text = null;
                    SoldSlotChild[i].CostText.text = null;
                    SoldSlotChild[i].Icon = null;
                }
                else
                {
                    SoldSlotChild[i].Furniture = SoldItems[i];
                    SoldSlotChild[i].NameText.text = SoldItems[i].FurnitureName;
                    SoldSlotChild[i].StyleText.text = SoldItems[i].Style;
                    SoldSlotChild[i].CostText.text = SoldItems[i].SellValue.ToString();
                    SoldSlotChild[i].Icon = SoldItems[i].sprite;
                }
            }
        }
    }

    public void Buy()
    {
        BuyTab.SetActive(true);
        SellTab.SetActive(false);
    }
    public void Sell()
    {
        SellTab.SetActive(true);
        BuyTab.SetActive(false);
    }
}
