using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureInteractable : MonoBehaviour
{

    public bool interactable = false;
    public bool CarryingFurniture = false;
    public bool Placeable;
    public bool floorPattern;
    public SpriteRenderer SL;
    public FloorGrid floorPrefabSprite;
    private BoxCollider2D floorCollider;
    public GameObject Furniture;
    public Transform MouseParent;
    public GameObject floorPrefab;

    //Check If Object is interactable
    //if Interactable is true allow object to be PICKEDUP
    //Check if the object is furniture
    //If the object is furniture check what type of furniture

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && interactable == true)
        {
            if (SL.sortingLayerName == "FloorPattern")
            {
                floorPattern = true;
            }
            if (MouseParent.transform.childCount >= 1)
            {
                if (SL.sortingLayerName == "Accessories")
                {
                    AttachFurniture();
                } 
            }
            if (MouseParent.transform.childCount >= 2)
            {
                Debug.Log("Cannot Carry Another Peice Of Furniture");
            }
           else
           {
               AttachFurniture();
               CarryingFurniture = true;
            }
            
        }
        if (Input.GetMouseButtonDown(1) && interactable == true && SL.sortingLayerName == "Accessories")
        {
            AttachAccessory();
        }
        if (CarryingFurniture == true && Input.GetButtonDown("PickUp"))
        {
            DetachFurniture();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactable = true;
        }
        if (collision.CompareTag("Furniture"))
        {
            if (SL.sortingLayerName != "Accessories")
            {
                Placeable = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = false;
        Placeable = true;
    }

    private void AttachFurniture()
    {
        if (interactable == true)
        {
            Placeable = true;
            Furniture.transform.SetParent(MouseParent);
            Furniture.transform.localPosition = new Vector2(0, 0);
        }
    }
    private void DetachFurniture()
    {
        if (Placeable == true)
        {
            if (floorPattern == true)
            {
                floorPrefab = GameObject.Find("FloorPatternHolder");
                floorPrefabSprite = floorPrefab.GetComponent<FloorGrid>();
                floorPrefabSprite.prefab = Furniture;
                floorCollider = Furniture.GetComponent<BoxCollider2D>();
                floorCollider.enabled = false;
            }
            Furniture.transform.SetParent(null);
        }
    
        else
        {
            Debug.Log("Cannot Place This Furniture Here");
        }
        
        CarryingFurniture = false;
        floorPattern = false;
        Placeable = false;
        
        
    }
    private void AttachAccessory()
    {
        if (interactable == true && SL.sortingLayerName == "Accessories")
        {
            Placeable = true;
            Furniture.transform.SetParent(MouseParent);
            Furniture.transform.localPosition = new Vector2(0, 0);
        }
    }

    



}
