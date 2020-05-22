using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRayCast : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(CursorLock.instance.mousePosition, Vector2.zero);
        if (hit != null && hit.collider != null)
        {
            Debug.Log(GameObject.Find(hit.collider.gameObject.name));
        }
        if (hit.transform.CompareTag("Wall"))
        {
            if (CursorLock.instance.Furniture.furnitureType != FurnitureScriptableObject.FurnitureType.WallFurniture)
            {
                CursorLock.instance.AllowPlace = false;
            }
            else
            {
                CursorLock.instance.AllowPlace = true;
            }
        }
        if (hit.transform.CompareTag("Furniture"))
        {
            if (CursorLock.instance.Furniture.furnitureType != FurnitureScriptableObject.FurnitureType.Accessories)
            {
                CursorLock.instance.AllowPlace = false;
            }
            else
            {
                CursorLock.instance.AllowPlace = true;
            }
        }
        if (hit.transform.CompareTag("Floor"))
        {
            if (CursorLock.instance.Furniture.furnitureType == FurnitureScriptableObject.FurnitureType.WallFurniture)
            {
                CursorLock.instance.AllowPlace = false;
            }
            else
            {
                CursorLock.instance.AllowPlace = true;
            }
        }


    }
}
