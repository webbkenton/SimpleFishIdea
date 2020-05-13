using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWindow : MonoBehaviour
{
    public GameObject shopWindow;

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
