using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float thrustForce;
    public float knockTime;
    private bool EnemyInRange = false;
    public Rigidbody2D enemy;

    private void Update()
    {
        if (enemy != null && Input.GetKeyDown(KeyCode.X))
        {
            //Debug.Log("XPress");
            Vector2 difference = enemy.transform.position - transform.position;
            difference = difference.normalized * thrustForce;
            enemy.constraints = RigidbodyConstraints2D.FreezeRotation;
            enemy.AddForce(difference, mode: ForceMode2D.Impulse);
            //Debug.Log("Yeet");
            StartCoroutine(Knock(enemy));
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("EnemyFound");
            enemy = collision.GetComponent<Rigidbody2D>();
            EnemyInRange = true;
        }
    }

    public void EnemyNull()
    {
        enemy = null;
    }

    private IEnumerator Knock(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.constraints = RigidbodyConstraints2D.FreezeAll;

        }
    }
}
