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
