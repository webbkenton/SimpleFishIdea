using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureEventListener : MonoBehaviour
{

    public GameObject Furniture;
    public Transform PlayerParent;

    void Start()
    {
        GameEvents.current.onFurniturePickUp += OnFurniturePickup;
    }

    private void Update()
    {
        if (Input.GetButtonDown("PickUp"))
        {
            Furniture.transform.SetParent(null);
        }
    }


    private void OnFurniturePickup()
    {
        Furniture.transform.SetParent(PlayerParent);
        Furniture.transform.localPosition = new Vector2(1, 0);
    }
}
