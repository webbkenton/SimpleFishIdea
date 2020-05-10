﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{
    public Texture2D cursorArrow;
    static Vector3 mousePosition;
    private float mouseSpeed = 1f;
    public bool holdingItem;
    public bool touchingWall;
    //public GameObject cursorObject;

    void Start()
    {
        
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
    private void Update()
    {
        if (transform.childCount > 0)
        {
            holdingItem = true;
            
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.x = Mathf.Round(mousePosition.x);
            mousePosition.y = Mathf.Round(mousePosition.y);
            mousePosition.x = Mathf.Clamp(mousePosition.x, - 8.75f, 8.75f);
            mousePosition.y = Mathf.Clamp(mousePosition.y, -5.75f, 5.75f);
            mousePosition.z = 0f;
            transform.position = mousePosition * mouseSpeed;

        }
        // if the item is wall furniture
        // Remove the clamp so the mouse can access outer wall
        // When the item is dropped Place the clamp back on
              
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Furniture"))
        {
            transform.position.Normalize();
        }
        if (collision.CompareTag("WallFurniture"))
        {
            mousePosition.x = Mathf.Round(mousePosition.x);
            mousePosition.y = Mathf.Round(mousePosition.y);
            touchingWall = true;

        }
    }


}

