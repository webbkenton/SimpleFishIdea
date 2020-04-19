using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurniturePlacement : MonoBehaviour
{
    private Vector3 mousePosition;
    public GameObject Furniture;
    public GameObject player;
    //public FurnitureScriptableObject NewFurniture;


    //public void AddObjectToGrid()
    //{
    //    if (Input.GetKeyDown(KeyCode.B))
    //    {
    //        Instantiate(NewFurniture);
    //    }
    //}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = (Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(Furniture);
            //ScriptableObject.CreateInstance("NewFurniture");
            Furniture.transform.position = mousePosition;
            
        }
        
    }
}
