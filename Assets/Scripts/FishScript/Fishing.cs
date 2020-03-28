using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Fishing : MonoBehaviour
{
    [SerializeField] public GameObject fishCaught;
    public GameObject questionBox;
    public GameObject buttonYes;
    public GameObject buttonNo;
    public GameObject Another;
    public bool playerInRange;

    private void Start()
    {
        StartCoroutine(Catch());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (questionBox.activeInHierarchy)
            {
                questionBox.SetActive(false);
            }
            else
            {
                questionBox.SetActive(true);
                buttonNo.SetActive(true);
                buttonYes.SetActive(true);
            }
        }
    }
    public IEnumerator Catch()
    {
        yield return new WaitForSeconds(1f - 5f);
        fishCaught.SetActive(true);
        if (fishCaught == true)
        {
            
        }
        
    }
    public void Delay()
    {
        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
        questionBox.SetActive(false);
    }
    public void Celebrate()
    {
        fishCaught.SetActive(false);
        questionBox.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            questionBox.SetActive(false);
        }
        
    }
}
