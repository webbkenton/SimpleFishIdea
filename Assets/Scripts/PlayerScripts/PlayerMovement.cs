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

    private SpriteRenderer spriteRenderer;
    public Sprite Grasssprite;
    public RuntimeAnimatorController GrassAnimator;

    public float attackRate = 2f;

    public Transform attackPoint;

    public GameObject attackPointLeft;
    public GameObject attackPointRight;
    public GameObject attackPointUp;
    public GameObject attackPointDown;
    public GameObject attackPointCenter;

    public float attackRange = .5f;
    public LayerMask enemyLayers;
    public int attackDamage = 10;
    private float nextAttackTime = 0f;
    public bool freeze;

    public LayerMask EnvObjects;
    public Animator CamAnim;

    public List<GameObject> consumedMaterial;

    public float grass;
    public float fire;
    public float water;
    public float air;
    public float light;

    public bool noForm;
    public bool grassForm;

    private void MaterialComposition()
    {
        if (grass >= 1)
        {
            //animator.Play("PinkyTransformGrass");
            StartCoroutine(GrassTransform());
        }
    }
    private IEnumerator GrassTransform()
    {
        grassForm = true;
        yield return new WaitForSeconds(1f);
        animator.Play("PinkyTransformGrass");
        yield return new WaitForSeconds(2f);
        spriteRenderer.sprite = Grasssprite;
        animator.runtimeAnimatorController = GrassAnimator;

    }

    private void Start()
    {
        noForm = true;
        animator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        transform.position = startingPosition.initalValue;
    }
    private void AttackPointMovement()
    {
        if (animator.GetFloat("LastX") >= 0.1)
        {
            attackPoint = attackPointRight.transform;

        }

        if (animator.GetFloat("LastX") <= -0.1)
        {
            attackPoint = attackPointLeft.transform;

        }

        if (animator.GetFloat("LastY") >= 0.1)
        {
            attackPoint = attackPointUp.transform;

        }

        if (animator.GetFloat("LastY") <= -0.1)
        {
            attackPoint = attackPointDown.transform;

        }
    }
    private void Attack()
    {
        GrassFormBlades();
        NoForm();
    }

    private void NoForm()
    {
        if (Input.GetKeyDown(KeyCode.Space) && noForm)
        {
            animator.SetTrigger("Attack");
            AttackPointMovement();

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
        if (Input.GetKeyDown(KeyCode.X) && noForm)
        {
            animator.SetTrigger("Plunge");

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
    private void GrassFormBlades()
    {

        if (Input.GetKeyDown(KeyCode.Space) && grassForm)
        {
            animator.SetTrigger("Attack");
            AttackPointMovement();

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
        if (Input.GetKeyDown(KeyCode.X) && grassForm)
        {
            animator.SetTrigger("Blades");

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
        if (freeze)
        {
            movement.x = 0f;
            movement.y = 0f;
        }

        MaterialComposition();
        //Punching();
        LungeAndPlunge();
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
            freeze = true;
            StartCoroutine("StopForAnimation");
            animator.Play("PinkyMunch");
            animator.SetBool("Chomped", true);
        }
    }
    private IEnumerator StopForAnimation()
    {
        Debug.Log("StoppingForAnimation");
        yield return new WaitForSeconds(1f);
        freeze = false;
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
        if (Input.GetKeyDown("x"))
        {
            holdStart = Time.time;

            //}
            //if (Input.GetKey(KeyCode.X))
            //{
            //    holdTime = Time.time - holdStart;

            //}
            //if (Input.GetKey("x") && holdTime >= .5f)
            //{
            freeze = true;
            CamAnim.Play("QuakeShake");
            animator.SetBool("LPComplete", true);
            StartCoroutine(StopForAnimation());
            animator.Play("PinkyLungeAndPlungeDown");
            //StartCoroutine(WaitForThePlunge());
            plungeCollider.enabled = true;
            animator.SetBool("Held", false);
            attackPoint = attackPointCenter.transform.transform;
            if (movement.x <= -.01f)
            {
                animator.SetBool("LPComplete", true);
                animator.Play("PinkyLungeAndPlungeLeft");
                //StartCoroutine(WaitForThePlunge());
                //plungeCollider.enabled = true;
                animator.SetBool("Held", false);

                //DestroyEnv();
            }
            if (movement.x >= .01f)
            {
                animator.SetBool("LPComplete", true);
                animator.Play("PinkyLungeAndPlungeRight");
                //StartCoroutine(WaitForThePlunge());
                ///plungeCollider.enabled = true;
                animator.SetBool("Held", false);

                //DestroyEnv();
            }
            if (movement.y <= -.01f)
            {
                animator.SetBool("LPComplete", true);
                animator.Play("PinkyLungeAndPlungDown");
                //StartCoroutine(WaitForThePlunge());
                //plungeCollider.enabled = true;
                animator.SetBool("Held", false);

                //DestroyEnv();
            }
            if (movement.y >= .01f)
            {
                animator.SetBool("LPComplete", true);
                animator.Play("PinkyLungeAndPlungeUp");
                //StartCoroutine(WaitForThePlunge());
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
