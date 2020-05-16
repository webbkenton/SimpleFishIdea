using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSquare : MonoBehaviour
{
    private Animator animator;
    private Transform myTransform;
    private Rigidbody2D myRigidbody2D;
    private Vector3 directionVector;
    public float speed;
    private int Direction;
    private Vector3 newDirection;
    private Vector3 Square1;
    private Vector3 Square2;
    private Vector3 Square3;
    private Vector3 Square4;

    private void Start()
    {
        Square1 = new Vector3(10, 7, 0);
        Square2 = new Vector3(-10, 7, 0);
        Square3 = new Vector3(-10, -5, 0);
        Square4 = new Vector3(10, -5, 0);
        animator = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (myTransform.position == Square1)
        {
            Direction = 0;
        }
        if (myTransform.position == Square2)
        {
            Direction = 1;
        }
        if (myTransform.position == Square3)
        {
            Direction = 2;
        }
        if (myTransform.position == Square4)
        {
            Direction = 3;
        }
        Move();
        UpdateAnimation();
    }
    private void Move()
    {
        FourSquare();
        myTransform.position = Vector3.MoveTowards(myTransform.position, directionVector, speed * Time.deltaTime);
        //Vector3 temp = directionVector;
        //myRigidbody2D.MovePosition(temp);
    }

    void FourSquare()
    {
        switch (Direction)
        {
            case 0:
                directionVector = new Vector3(-10, 7, 0);
                newDirection = Vector3.left;
                break;
            case 1:
                directionVector = new Vector3(-10, -5, 0);
                newDirection = Vector3.down;
                break;
            case 2:
                directionVector = new Vector3(10, -5, 0);
                newDirection = Vector3.right;
                break;
            case 3:
                directionVector = new Vector3(10, 7, 0);
                newDirection = Vector3.up;
                break;
            default:
                break;
        }
    }

    void UpdateAnimation()
    {
        animator.SetFloat("MoveX", newDirection.x);
        animator.SetFloat("MoveY", newDirection.y);
        animator.SetFloat("Speed", speed);
    }
}
