using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public bool shopwindow;
    public GameObject Shop;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("CloseShop"))
        {
            UIManager.instance.Shop.SetActive(!UIManager.instance.Shop.activeSelf);
        }
        if (Shop.activeInHierarchy)
        {
            shopwindow = true;
        }
        if (!Shop.activeInHierarchy)
        {
            shopwindow = false;
        }
    }
}
