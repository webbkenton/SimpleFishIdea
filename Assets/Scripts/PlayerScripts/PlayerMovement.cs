using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 movement;

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public VectorValue startingPosition;


    private void Start()
    {

        transform.position = startingPosition.initalValue;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();


        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement != Vector2.zero)
        {
            animator.SetFloat("LastX", movement.x);
            animator.SetFloat("LastY", movement.y);
        }
        Punching();
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void Punching()
    {
        if (movement.x <= -.01f && Input.GetKeyDown("space"))
        {
            animator.SetBool("Punched", true);
            animator.Play("PinkyPunchLeft");
            
        }
        if (movement.x >= .01f && Input.GetKeyDown("space"))
        {
            animator.Play("PinkyPunchRight");
            animator.SetBool("Punched", true);
        }
        if (movement.y <= -.01f && Input.GetKeyDown("space"))
        {
            animator.Play("PinkyPunchDown");
            animator.SetBool("Punched", true);
        }
        if (movement.y >= .01f && Input.GetKeyDown("space"))
        {
            animator.Play("PinkyPunchUp");
            animator.SetBool("Punched", true);
        }
        WaitForThePunch();
    }

    private IEnumerator WaitForThePunch()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("Punched", false);

    }
}
