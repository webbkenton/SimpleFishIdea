using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCPlayerInRange : MonoBehaviour
{
    public bool playerInRange;
    public Animator animator;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.CompareTag("Player");
        playerInRange = true;
        animator.SetBool("playerInRange", true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.CompareTag("Player");
        playerInRange = false;
        animator.SetBool("playerInRange", false);
    }
}
