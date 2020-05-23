using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Furniture")]
public class FurnitureScriptableObject : ScriptableObject
{
    public string FurnitureName = "Furniture Name";
    public int PurchaseValue = 100;
    public int SellValue = 75;
    public string Style = "Default";
    public Sprite sprite = null;
    public FurnitureSize furnitureSize;
    public FurnitureType furnitureType;

    public enum FurnitureSize
    {
        Small,
        Medium,
        Large
    }
    public enum FurnitureType
    {
        Floor,
        Wall,
        GroundFurniture,
        WallFurniture,
        Accessories
    }

    public void Use()
    {
        if (UIManager.instance.Shop.activeInHierarchy)
        {
            CurrencyManager.instance.CurrentGold += SellValue;
            Inventory.instance.FurnitrueRemove(this);
            UIManager.instance.Shop.GetComponentInChildren<FurnitureShopWindow>().SoldItems.Add(this);
        }
        else
        {
            return;
        }
        if (!UIManager.instance.Shop.activeInHierarchy)
        {
            CursorLock.instance.Furniture = this;
            CursorLock.instance.SquareTracker.SetActive(true);
            CursorLock.instance.cursorObject.SetActive(true);
            CursorLock.instance.AllowPlace = true;
            CursorLock.instance.ObjectRenderer.sprite = this.sprite;
            //on the mouse if Input // remove object from inventory
            //instantiate object at PlacementObject.Transform
        }
    }
}
