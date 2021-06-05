using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalObject : MonoBehaviour
{
    public int MaxHealth = 10;
    private int currentHealth;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        animator = this.GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Die Called");


        animator.SetBool("IsDead", true);
        GetComponent<CircleCollider2D>().enabled = false;
        this.GetComponent<TreeTransparent>().enabled = false;
        this.enabled = false;
        this.GetComponent<SpriteRenderer>().sortingLayerName = "Path";

    }
}
