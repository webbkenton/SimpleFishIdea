using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGrid : MonoBehaviour
{
    public float xStart, yStart;
    public int collumnLength, rowLength;
    private int gridSpace;
    public float xSpace, ySpace;
    public GameObject prefab;
    private GameObject oldPrefab;
    private GameObject[] oldFloor;
    // Start is called before the first frame update
    void Start()
    {
        gridSpace = collumnLength * rowLength;
        for (int i = 0; i < gridSpace; i++)
        {
            Instantiate(prefab, new Vector3(xStart + (xSpace * (i % collumnLength)), yStart + (ySpace * (i / collumnLength))), Quaternion.identity);
            prefab.tag = ("PlacedFloor");
        }
        oldPrefab = prefab;
    }

    // Update is called once per frame
    void Update()
    {
        if (oldPrefab != prefab)
        {
            DestoryOldFloor();
            UpdateFloor();
        }
        
        
        //if (Input.GetMouseButtonDown(0))
        //{
            
        //    if (CompareTag("FloorPattern"))
        //    {
        //        prefab = 
        //    }
        //}
        // if the player is holding a floor object prefab
        // replace the Holder prefab with the new prefab
        //the update the floor pattern
    }

    private void UpdateFloor()
    { 
        for (int i = 0; i < collumnLength * rowLength; i++)
        {
            Instantiate(prefab, new Vector3(xStart + (xSpace * (i % collumnLength)), yStart + (ySpace * (i / collumnLength))), Quaternion.identity);
            prefab.tag = ("PlacedFloor"); 
        }
        oldPrefab = prefab;
       
    }
    private void DestoryOldFloor()
    {
        oldFloor = GameObject.FindGameObjectsWithTag("PlacedFloor");
        //Instantiate(oldPrefab);
        for (int i = 0; i < oldFloor.Length; i++)
        {
            GameObject.Destroy(oldFloor[i]);
        }
    }
}
