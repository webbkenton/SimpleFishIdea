using System.Collections;
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
    private Vector2 Target2;
    private Vector2 Target3;
    private Vector2 Target4;
    
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
