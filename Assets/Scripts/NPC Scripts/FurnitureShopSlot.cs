using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FurnitureShopSlot : MonoBehaviour
{
    public FurnitureScriptableObject Furniture;
    public GameObject ShopParent;
    public TMP_Text NameText;
    public TMP_Text CostText;
    public TMP_Text StyleText;
    public Image IconImage;
    public Sprite Icon;

    private void Update()
    {
        IconImage.sprite = Icon;
    }
    public void Purchase()
    {
        if (CurrencyManager.instance.CurrentGold >= Furniture.PurchaseValue)
        {
            Inventory.instance.AddFurnitue(Furniture);
            CurrencyManager.instance.CurrentGold -= Furniture.PurchaseValue;
            Instantiate(Furniture);
            
        }
    }
    public void BuyBack()
    {
        if (CurrencyManager.instance.CurrentGold >= Furniture.SellValue)
        {
            Inventory.instance.AddFurnitue(Furniture);
            CurrencyManager.instance.CurrentGold -= Furniture.PurchaseValue;
            Instantiate(Furniture);
            UIManager.instance.Shop.GetComponent<FurnitureShopWindow>().SoldItems.Remove(Furniture);
            EmptySlot();
        }
    }

    public void EmptySlot()
    {
        Furniture = null;
        IconImage.enabled = false;
        Icon = null;
        
    }
}
