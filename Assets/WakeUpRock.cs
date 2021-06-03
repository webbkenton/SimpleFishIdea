using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpRock : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("WakeUp", true);
            StartCoroutine("RockStand");
        }
    }

    private IEnumerator RockStand()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("StandComplete", true);
        this.GetComponent<EnemyAI>().enabled = true;
    }
}
