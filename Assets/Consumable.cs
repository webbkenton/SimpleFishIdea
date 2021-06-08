using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    private bool consumable;
    // Update is called once per frame
    void Update()
    {
        if (consumable && Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Consumption");
            //Also need to get the type of consumable object possible to do with multiple tags.
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerMovement>().consumedMaterial.Add(this.gameObject);
            StartCoroutine(FindConsumableType());
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            consumable = true;
        }

    }

    private IEnumerator FindConsumableType()
    {
        Debug.Log("Started");
        if (this.CompareTag("ConsumableGrass"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerMovement>().grass++;
            Debug.Log("Finished");

        }
        yield return 0;
    }
}
