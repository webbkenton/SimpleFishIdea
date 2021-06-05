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
    private float holdTime;
    private float holdStart;
    public CircleCollider2D plungeCollider;
    public GameObject ripple;

    public float attackRate = 2f;
    public Transform attackPoint;
    public float attackRange = .5f;
    public LayerMask enemyLayers;
    public int attackDamage = 10;
    private float nextAttackTime = 0f;

    public LayerMask EnvObjects;

    private void Start()
    {

        transform.position = startingPosition.initalValue;
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyAI>().TakeDamage(attackDamage);
            }

            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, EnvObjects);
            foreach (Collider2D envObject in hitObjects)
            {
                Debug.Log("Env");
                envObject.GetComponent<EnvironmentalObject>().TakeDamage(attackDamage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
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
        //Punching();
        //LungeAndPlunge();
        Chomp();
        Attack();
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void Punching()
    {
        if (Input.GetKeyUp("space") && holdTime <= .49f)
        {
            if (movement.x <= -.01f)
            {
                animator.SetBool("Punched", true);
                animator.Play("PinkyPunchLeft");

            }
            if (movement.x >= .01f)
            {
                animator.Play("PinkyPunchRight");
                animator.SetBool("Punched", true);
            }
            if (movement.y <= -.01f)
            {
                animator.Play("PinkyPunchDown");
                animator.SetBool("Punched", true);
            }
            if (movement.y >= .01f)
            {
                animator.Play("PinkyPunchUp");
                animator.SetBool("Punched", true);
            }
            WaitForThePunch();
        }
    }

    private void Chomp()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.Play("PinkyMunch");
            animator.SetBool("Chomped", true);
        }
    }

    //private void DestroyEnv()
    //{
    //    Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, EnvObjects);
    //    foreach (Collider2D ENVobject in hitObjects)
    //    {
    //        ENVobject.GetComponent<EnvironmentalObject>().TakeDamage(attackDamage);
    //    }
    //}
    private void LungeAndPlunge()
    {
        if (Input.GetKeyDown("space"))
        {
            holdStart = Time.time;
            
        }
        if (Input.GetKey(KeyCode.Space))
        {
            holdTime = Time.time - holdStart;
            
        }
        if (Input.GetKey("space") && holdTime >= .5f)
        {
            //animator.SetBool("Held", true);
            //plungeCollider.enabled = true;
            //StartCoroutine(WaitForThePlunge());
            if (movement.x <= -.01f)
            {
                animator.SetBool("LPComplete", true);
                animator.Play("PinkyLungeAndPlungeLeft");
                StartCoroutine(WaitForThePlunge());
                //plungeCollider.enabled = true;
                animator.SetBool("Held", false);
                
                //DestroyEnv();
            }
            if (movement.x >= .01f)
            {
                animator.SetBool("LPComplete", true);
                animator.Play("PinkyLungeAndPlungeRight");
                StartCoroutine(WaitForThePlunge());
                ///plungeCollider.enabled = true;
                animator.SetBool("Held", false);
                
                //DestroyEnv();
            }
            if (movement.y <= -.01f)
            {
                animator.SetBool("LPComplete", true);
                animator.Play("PinkyLungeAndPlungDown");
                StartCoroutine(WaitForThePlunge());
                //plungeCollider.enabled = true;
                animator.SetBool("Held", false);
               
                //DestroyEnv();
            }
            if (movement.y >= .01f)
            {
                animator.SetBool("LPComplete", true);
                animator.Play("PinkyLungeAndPlungeUp");
                StartCoroutine(WaitForThePlunge());
                //plungeCollider.enabled = true;
                animator.SetBool("Held", false);
                
                //DestroyEnv();
            }
        }
    }
    private IEnumerator WaitForThePunch()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("Punched", false);

    }

    private IEnumerator WaitForThePlunge()
    {
        Debug.Log("Starting");
        yield return new WaitForSeconds(.5f);
        ripple.SetActive(true);
        //animator.SetBool("LPComplete", false);
        yield return new WaitForSeconds(1f);
        animator.SetBool("Held", false);
        ripple.SetActive(false);
    }
}
