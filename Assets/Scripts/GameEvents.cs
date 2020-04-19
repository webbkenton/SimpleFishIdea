using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onFurniturePickUp;
    public void FurniturePickUp()
    {
        if (onFurniturePickUp != null)
        {
            onFurniturePickUp();
        }
    }


   
}
