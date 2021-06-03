using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject InteractableIcon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveIcon();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(InteractableIcon);
            
            
            
        }
    }
    private void MoveIcon()
    {
        if (InteractableIcon.activeInHierarchy)
        {
            InteractableIcon.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
        }
    }
}
