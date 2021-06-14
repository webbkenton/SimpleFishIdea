using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public string[] Sentences;
    public GameObject InteractableIcon;
    public UIManager uIManager;
    public bool inRange = false;
    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        EToInteract();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InteractableIcon.SetActive(true);
            uIManager.sentences = Sentences;
            inRange = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
        {
            InteractableIcon.SetActive(false);
        }
    }
    private void EToInteract()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            uIManager.UpdateTyping();
            uIManager.dialogText.gameObject.SetActive(true);
        }
    }
}
