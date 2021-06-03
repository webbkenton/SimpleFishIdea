using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingRock : MonoBehaviour
{
    private bool Breakable;
    void Update()
    {
        DestroyRock();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Breakable = true;
        }
    }

    private void DestroyRock()
    {
        if (Breakable == true && Input.GetKeyDown("space"))
        {
            ///WaitForPunch();
            this.gameObject.SetActive(false);
            LoadNextRock();
        }
    }
    private IEnumerator WaitForPunch()
    {
        yield return new WaitForSeconds(3f);
        if (GameObject.FindGameObjectsWithTag("BrokenRock1") == null)
        {
            GameObject brokenRock2 = GameObject.FindGameObjectWithTag("BrokenRock2");
            brokenRock2.SetActive(true);
        }
        GameObject brokenRock1 = GameObject.FindGameObjectWithTag("BrokenRock1");
        brokenRock1.SetActive(true);
    }

    private void LoadNextRock()
    {
        if (GameObject.FindGameObjectWithTag("BrokenRock0") == null && GameObject.FindGameObjectWithTag("BrokenRock1") != null)
        {
           GameObject brokenRock1 = GameObject.FindGameObjectWithTag("BrokenRock1");
            if (brokenRock1.GetComponent<BreakingRock>().enabled == false)
            {
                GameObject.FindGameObjectWithTag("BrokenRock1").GetComponent<BreakingRock>().enabled = true;
            }

            
        }
    }
}
