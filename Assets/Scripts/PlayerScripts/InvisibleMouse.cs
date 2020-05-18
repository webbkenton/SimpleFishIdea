using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleMouse : MonoBehaviour
{
    public Vector3 mousePosition;
    public bool overFurniture;
    public FurnitureScriptableObject Furniture;
    public GameObject FurnitureGameObject;
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        transform.position = mousePosition;

        if (Input.GetMouseButtonDown(0) && overFurniture == true)
        {
            Inventory.instance.AddFurnitue(Furniture);
            Destroy(FurnitureGameObject);
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Furniture"))
        {
            overFurniture = true;
            FurnitureGameObject = collision.gameObject;
            Furniture = collision.gameObject.GetComponent<FurnitureChild>().furniture;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        overFurniture = false;
        FurnitureGameObject = null;
        Furniture = null;
    }
}
