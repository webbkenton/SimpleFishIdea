using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGrid : MonoBehaviour
{
    public float xStart, yStart;
    public int collumnLength, rowLength, gridSpace;
    public float xSpace, ySpace;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        gridSpace = collumnLength * rowLength;
        for (int i = 0; i < gridSpace; i++)
        {
            Instantiate(prefab, new Vector3(xStart + (xSpace * (i % collumnLength)), yStart + (ySpace * (i / collumnLength))), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFloor();
        if (Input.GetMouseButtonDown(0))
        {
            
        //    if (CompareTag("FloorPattern"))
        //    {
        //        prefab = 
        //    }
        }
        // if the player is holding a floor object prefab
        // replace the Holder prefab with the new prefab
        //the update the floor pattern
    }

    private void UpdateFloor()
    {
        //Delete the old Game Objects
        prefab = GameObject.Find("GameObject(Clone)");
        for (int i = 0; i < gridSpace; i++)
        {
            Destroy(prefab);
        }

        //for (int i = 0; i < collumnLength * rowLength; i++)
        //{
        //    Instantiate(prefab, new Vector3(xStart + (xSpace * (i % collumnLength)), yStart + (ySpace * (i / collumnLength))), Quaternion.identity);
        //}
    }
}
