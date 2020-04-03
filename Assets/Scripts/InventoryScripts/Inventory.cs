﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than 1 inventory!");
            return;
               
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public int space = 12;
    public List<Item> items = new List<Item>();
    public List<Fish> fishs = new List<Fish>();

    public bool add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough space");
                return false;
            }
            items.Add(item);
            if (onItemChangedCallBack != null)
            {
                onItemChangedCallBack.Invoke();
            }
            
        }

        return true;
    }
    public bool AddFish(Fish fish)
    {
        if (fishs.Count >= space)
            {
                Debug.Log("Not enough space");
                return false;
            }
        fishs.Add(fish);
        if (onItemChangedCallBack != null)
            {
                onItemChangedCallBack.Invoke();
            }

        return true;
    }

    public void remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
    }
    public void fishRemove(Fish fish)
    {
        fishs.Remove(fish);

        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
    }

}
