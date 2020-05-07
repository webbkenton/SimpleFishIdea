using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGrid : MonoBehaviour
{
    public float xStart, yStart;
    public int collumnLength, rowLength;
    public float xSpace, ySpace;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < collumnLength * rowLength; i++)
        {
            Instantiate(prefab, new Vector3(xStart + (xSpace * (i % collumnLength)), yStart + (ySpace * (i / collumnLength))), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
