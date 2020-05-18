using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorLock : MonoBehaviour
{
    public static CursorLock instance;
    //public Texture2D cursorArrow;
    static Vector3 mousePosition;
    private Vector3 ClickLocation;
    private float mouseSpeed = 1f;
    public GameObject SquareTracker;
    public bool holdingItem;
    public bool AllowPlace;
    public GameObject FurniturePrefab;
    public SpriteRenderer ObjectRenderer;
    public Color greenCircle;
    public GameObject cursorObject;
    public FurnitureScriptableObject Furniture = null;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SquareTracker.SetActive(false);
        greenCircle = SquareTracker.GetComponent<SpriteRenderer>().color;
        //Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        SquareTracker.transform.position = mousePosition;
        ObjectRenderer = cursorObject.GetComponent<SpriteRenderer>();
        ObjectRenderer.color = new Color(ObjectRenderer.color.r, ObjectRenderer.color.g, ObjectRenderer.color.b, .5f);
        mousePosition.x = Mathf.Round(mousePosition.x) +.5f;
        mousePosition.y = Mathf.Round(mousePosition.y) +.5f;
        //    mousePosition.x = Mathf.Clamp(mousePosition.x, - 8.75f, 8.75f);
        //    mousePosition.y = Mathf.Clamp(mousePosition.y, -5.75f, 5.75f);
        transform.position = mousePosition * mouseSpeed;
        FurniturePrefab.GetComponent<FurnitureChild>().furniture = Furniture;
        if (Input.GetMouseButtonDown(0) && AllowPlace == true)
        {
            ClickLocation = SquareTracker.transform.position;
            Debug.Log(ClickLocation);
            Instantiate(FurniturePrefab, ClickLocation, Quaternion.identity);
            cursorObject.SetActive(false);
            SquareTracker.SetActive(false);
            AllowPlace = false;
            Inventory.instance.FurnitrueRemove(Furniture);
            Furniture = null;
            
        }
        //}
        // if the item is wall furniture
        // Remove the clamp so the mouse can access outer wall
        // When the item is dropped Place the clamp back on
              
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(tag.Equals("WallFurniture"))
        if (collision.CompareTag("Furniture"))
        {
            AllowPlace = false;
            SquareTracker.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
            //transform.position.Normalize();
        }
        if (collision.CompareTag("Wall"))
        {
            if (Furniture.furnitureType == FurnitureScriptableObject.FurnitureType.WallFurniture)
            {
                AllowPlace = true;
            }
            else
            {
                AllowPlace = false;
                DenyPlace();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        AllowPlace = true;
        SquareTracker.GetComponent<SpriteRenderer>().color = greenCircle;

    }

    private void DenyPlace()
    {
        SquareTracker.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
    }



}

