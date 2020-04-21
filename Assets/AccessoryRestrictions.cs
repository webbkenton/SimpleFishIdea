using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryRestrictions : MonoBehaviour
{

    private bool placeable;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && placeable == true)
        {
            transform.SetParent(null);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GroundFurniture"))
        {
            placeable = true;
        }
        else
        {
            placeable = false;
            //transform.localPosition = new Vector2(1, 1);
        }
    }

}
