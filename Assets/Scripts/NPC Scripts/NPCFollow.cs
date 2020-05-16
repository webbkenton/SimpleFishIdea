using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    private Animator animator;
    private Transform myTransform;
    private Rigidbody2D myRigidbody2D;
    public float speed;
    private bool moving;
    public bool Follow;
    private Transform player;
    private Transform playerY;
    private Transform playerX;
    private Vector3 Horizontal;
    private Vector3 Vertical;
    private Vector3 BufferX;
    private Vector3 BufferY;

    private void Start()
    {
        BufferX = new Vector3(-1.5f,0, 0);
        BufferY = new Vector3(0, 1.5f, 0);
        animator = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        GetPlayer();
    }

    private void Update()
    {
        if (moving == false)
        {
            speed = 0;
        }
        
        if (Follow == true)
        {
            speed = 2f;
            moving = true;
            MoveX();
            UpdateAnimation();
            if (myTransform.position == playerX.transform.position)
            {
                Horizontal = Vector3.zero;
                UpdateAnimation();
                MoveY();
            }
        }
        else
        {
            speed = 0;
            UpdateAnimation();
        }
    }

    private void MoveX()
    {
        playerX.transform.position = new Vector3(player.transform.position.x, myTransform.position.y, 0);
        Debug.Log(playerX.transform.position);
        myTransform.position = Vector3.MoveTowards(myTransform.position, playerX.transform.position, speed * Time.deltaTime) ;
        if (myTransform.position.x <= playerX.transform.position.x)
        {
            Horizontal = Vector3.right;
            //Vertical = Vector3.zero;
        }
        if (myTransform.position.x >= playerX.transform.position.x)
        {
            Horizontal = Vector3.left;
            //Vertical = Vector3.zero;
        }
    }
    private void MoveY()
    {
        playerY.transform.position = new Vector3(myTransform.position.x, player.transform.position.y, 0);
        myTransform.position = Vector3.MoveTowards(myTransform.position, playerY.transform.position + BufferY, speed * Time.deltaTime);
        speed = 0;
        if (myTransform.position.y <= playerY.transform.position.y)
        {
            Vertical = Vector3.up;
           // Horizontal = Vector3.zero;
        }
        if (myTransform.position.y >= playerY.transform.position.y)
        {
            Vertical =Vector3.down;
            // Horizontal = Vector3.zero;
        }
    }
    void UpdateAnimation()
    {
        animator.SetFloat("MoveX", Horizontal.x);
        animator.SetFloat("MoveY", Vertical.y) ;
        animator.SetFloat("Speed", speed);
    }
    public void followButton()
    {
        Follow = true;
    }
    private void GetPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerX = GameObject.FindGameObjectWithTag("ChaseSquareX").GetComponent<Transform>();
        playerY = GameObject.FindGameObjectWithTag("ChaseSquareY").GetComponent<Transform>();
        //playerY = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //playerX.transform.position = new Vector3(player.transform.position.x, myTransform.position.y, 0);
        //playerY.transform.position = new Vector3(myTransform.position.x, player.transform.position.y, 0);

    }
}
