using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureChild : MonoBehaviour
{
    public bool interactable = false;
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
            transform.position = new Vector2(0, 0);
            sR.sortingLayerName = ("FurnitureFloor");
            
        }
        if (furniture.furnitureType == FurnitureScriptableObject.FurnitureType.Wall)
        {
            //sR.sortingLayerName = ("FurnitureFloor");
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
        if (Input.GetMouseButtonDown(0) && interactable == true)
        {
            GameEvents.current.FurniturePickUp();
            pickedUp = true;
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactable = true;
        }
        if (collision.CompareTag("Furniture") && pickedUp == true)
        {
            bodyType = GetComponent<Rigidbody2D>();
            bodyType.bodyType = RigidbodyType2D.Dynamic;
            transform.position = transform.parent.position;
            //if (transform.position.x > .5f)
            //{
            //    Debug.Log(transform.position.x + "x");
            //    transform.position = startingPosition;
            //    pickedUp = false;
            //    transform.SetParent(null);
            //    bodyType.bodyType = RigidbodyType2D.Kinematic;
            //}
            //if (transform.position.y > .5f)
            //{
            //    Debug.Log(transform.position.y + "y");
            //    transform.position = startingPosition;
            //    pickedUp = false;
            //    transform.SetParent(null);
            //    bodyType.bodyType = RigidbodyType2D.Kinematic;
            //}
            //if (transform.position.x < -.5f)
            //{
            //    Debug.Log(transform.position.x + "x");
            //    transform.position = startingPosition;
            //    pickedUp = false;
            //    transform.SetParent(null);
            //    bodyType.bodyType = RigidbodyType2D.Kinematic;
            //}
            //if (transform.position.y < -.5f)
            //{
            //    Debug.Log(transform.position.y + "y");
            //    transform.position = startingPosition;
            //    pickedUp = false;
            //    transform.SetParent(null);
            //    bodyType.bodyType = RigidbodyType2D.Kinematic;
            //}
        }
     
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = false;
    }

}
