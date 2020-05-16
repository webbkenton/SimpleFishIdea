using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    private Vector3 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D myRigidbody2D;
    private Animator animator;
    public Collider2D bounds;
    public float moveTime;
    public bool Stand;
    public float StoppingDistance;

    private void Start()
    {
        animator = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        myRigidbody2D.MovePosition(temp);
    }
    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                directionVector = Vector3.right;
                break;
            case 1:
                directionVector = Vector3.up;
                break;
            case 2:
                directionVector = Vector3.left;
                break;
            case 3:
                directionVector = Vector3.down;
                break;
            default:
                break;
        }
        UpdateAnimation();
        
    }
    void UpdateAnimation()
        {
        animator.SetFloat("MoveX", directionVector.x);
        animator.SetFloat("MoveY", directionVector.y);
        animator.SetFloat("Speed", speed);
        }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;

        while (temp == directionVector && loops < 100)
        {
            loops++;
            ChangeDirection();
        }
    }
    //All NPC's to walk in a square.
    //All NPC's should use their Animations
}
