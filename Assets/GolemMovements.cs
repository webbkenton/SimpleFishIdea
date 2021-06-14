using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemMovements : MonoBehaviour
{

    public Transform target;

    public float speed = 2f;
    public float stoppingDistance;
    public int MaxHealth = 300;
    private int currentHealth;
    private GameObject SceneProgressTracker;
    private bool PlayerInRange;
    public Animator CamAnim;
    private bool facingLeft;
    private bool facingRight;

    public int AttackDamage = 2;
    public Vector3 AttackOffset;
    public float AttackRange;
    public LayerMask PlayerLayers;
    public Transform attackPoint;

    public bool Damaged;
    public float DamagedTimer;
    public float UnDamaged;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        DamagedTimer = 2f;
        UnDamaged = DamagedTimer;
        animator = this.GetComponent<Animator>();
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        //HeavyAttack();
        UpdateFacing();
        WakeUpFromDamage();
    }

    private void WakeUpFromDamage()
    {
        if (UnDamaged >= 0)
        {
            UnDamaged -= Time.deltaTime;
        }
        if (UnDamaged <= 0)
        {
            UnDamaged = DamagedTimer;
            HeavyAttack();
        }
    }
    public void TakeDamage(int damage)
    {
        Damaged = true;
        currentHealth -= damage;
        Debug.Log(currentHealth);

        animator.SetTrigger("Hurt");
        //DamagedTimer = Time.deltaTime;
        WakeUpFromDamage();
        Damaged = false;

        if (currentHealth == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetBool("Isdead", true);
        this.tag = "DeadEnemy";
        GameObject.FindGameObjectWithTag("Player").GetComponent<KnockBack>().EnemyNull();
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<WakeUpRock>().enabled = false;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        //this.enabled = false;
    }


    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, AttackRange, PlayerLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<PlayerMovement>().TakeDamage(AttackDamage);
        }
    }
    private void UpdateFacing()
    {
        if (target.position.x >= 0)
        {
            facingRight = true;
            attackPoint = GameObject.FindGameObjectWithTag("EnemyAttackPointRight").transform;
            if (target.position.x >= 0 && !PlayerInRange && !Damaged)
            {
                animator.Play("GolemIdleRight");
                facingLeft = false;
            }
        }
        if (target.position.x <= 0)
        {
            facingLeft = true;
            attackPoint = GameObject.FindGameObjectWithTag("EnemyAttackPointLeft").transform;
            if (target.position.x <= 0 && !PlayerInRange && !Damaged)
            {
                animator.Play("GolemIdle");
                facingRight = false;
            }
        }
    }
    private void HeavyAttack()
    {
        if (PlayerInRange && facingLeft)
        {
            animator.Play("GolemSmashLeft");
            CamAnim.Play("QuakeShake");
            facingRight = false;
        }
        if (PlayerInRange && facingRight)
        {
            animator.Play("GolemSmashRight");
            CamAnim.Play("QuakeShake");
            facingLeft = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("PlayerInRange");
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("PlayerLeftRange");
            PlayerInRange = false;
        }
    }
}
