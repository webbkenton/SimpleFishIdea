using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureClick : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.x = Mathf.Round(mousePosition.x);
            mousePosition.y = Mathf.Round(mousePosition.y);
            mousePosition.z = 0f;
            //transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
            transform.position = mousePosition;
        }

    }
   
}
