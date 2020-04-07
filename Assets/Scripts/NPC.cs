using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{

    public GameObject dialogBox;
    public GameObject questDialog;
    public TMP_Text dialogText;
    public string dialog;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                questDialog.SetActive(false);
                //fishingButton.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                questDialog.SetActive(false);
                dialogText.text = dialog;
                //fishingButton.SetActive(true);
            }
        }

      
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        playerInRange = true;
                    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        playerInRange = false;
        dialogBox.SetActive(false);
    }
    public void QuestDialog()
    {
        if (Inventory.instance.fishs != null)
        {
            dialogBox.SetActive(false);
            questDialog.SetActive(true);
        }
    }
}
