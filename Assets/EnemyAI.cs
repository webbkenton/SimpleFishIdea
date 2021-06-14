using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public Transform target;

    public float speed = 2f;
    public float stoppingDistance;
    public int MaxHealth = 50;
    private int currentHealth;
    private GameObject SceneProgressTracker;

    private Animator animator;

    void Start()
    {
        SceneProgressTracker = GameObject.FindGameObjectWithTag("SceneProgressTracker");
        this.GetComponent<WakeUpRock>().enabled = false;
        animator = this.GetComponent<Animator>();
        currentHealth = MaxHealth;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void TakeDamage(int damage)
    { 
        currentHealth -= damage;
        Debug.Log(currentHealth);

        animator.SetTrigger("Hurt");

        if (currentHealth == 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (SceneProgressTracker != null)
        {
            SceneProgressTracker.GetComponent<SceneProgressTracker>().UpdateMockDeaths();
            SceneProgressTracker.GetComponent<SceneProgressTracker>().transforms.Add(this.transform);
            SceneProgressTracker.GetComponent<SceneProgressTracker>().animators.Add(this.animator);
        }
        animator.SetBool("Isdead", true);
        this.tag = "DeadEnemy";
        GameObject.FindGameObjectWithTag("Player").GetComponent<KnockBack>().EnemyNull();
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<WakeUpRock>().enabled = false;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        //this.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("Isdead") == false)
        {
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
    }
}
