﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public float Horizontal;
    public float Vertical;
    public float Speed;
    public bool Moving;
    private Rigidbody2D ThisRigidBody;
    public Transform NPCtransform;
    private Vector2 Target1;
    private void Start()
    {
        Target1 = new Vector2(-10, 7);
        NPCtransform = this.transform;
        NPCtransform.position = transform.position;
        ThisRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (NPCtransform.position.x == 10)
        {
            if (NPCtransform.position.y == 7)
            {
                NPCtransform.position = Mathf.Lerp(10, -10, Speed);
            }
        }
        if (NPCtransform.position.x == -10)
        {
            if (NPCtransform.position.y == 7)
            {
                
            }
            
        }
        
    }

    //All NPC's to walk in a square.
    //All NPC's should use their Animations
}
