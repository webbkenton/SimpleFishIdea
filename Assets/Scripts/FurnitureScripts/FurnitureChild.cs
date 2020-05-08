using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureChild : MonoBehaviour
{
    //public bool interactable = false;
    public FurnitureScriptableObject furniture;
    public Rigidbody2D bodyType;
    public bool pickedUp = false;
    public SpriteRenderer sR;
    private Vector3 startingPosition;
    private Vector3 wallPosition;

    private void Start()
    {
        startingPosition = transform.position;
        sR.sprite = furniture.Sprite;
        this.name = furniture.FurnitureName;
        //this.transform.localScale = new Vector2(20, 20);
    }

    private void Update()
    {
        if (furniture.furnitureType == FurnitureScriptableObject.FurnitureType.Floor)
        {
            //transform.position = new Vector2(0, 0);
            sR.sortingLayerName = ("FloorPattern");

        }
        if (furniture.furnitureType == FurnitureScriptableObject.FurnitureType.Wall)
        {
            sR.sortingLayerName = ("FurnitureFloor");
            sR.sortingOrder = 1;
        }
        if (furniture.furnitureType == FurnitureScriptableObject.FurnitureType.GroundFurniture)
        {
            sR.sortingLayerName = ("GroundFurniture");
        }
        if (furniture.furnitureType == FurnitureScriptableObject.FurnitureType.Accessories)
        {
            sR.sortingLayerName = ("Accessories");


        }
        //if (Input.GetMouseButtonDown(0) && interactable == true)
        //{
        //    GameEvents.current.FurniturePickUp();
        //    pickedUp = true;

        //}

    }

}
