using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWindow : MonoBehaviour
{
    public GameObject shopWindow;

    // Need Text for Name Value Size Style
    // Need Image for Icon
    // Need button for Purchase
    //Each Space in the ShopWindow will need to have A shopWindowItemScript
    //Shop window will need a List of items similar to Inventory
    //Inventory Updates UI through a sperate Script
    //Without an instance this will need to be done in the same Script
    //Done using a forLoop
    //Each shop will have its own Stock so we dont want to create an instance
    private void Update()
    {
        if (UIManager.instance.Shop == true)
        {
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shopWindow.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        shopWindow.SetActive(false);
    }
}
