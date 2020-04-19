using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureChild : MonoBehaviour
{
    //public GameObject furniture;

    //public Transform parentPlayer;
    public bool Interactable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameEvents.current.FurniturePickUp();
        }
        //if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.V))
        //{
            
        //    AttachToParent(parentPlayer);
        //}
        
    }

    //public void AttachToParent(Transform newParent)
    //{
    //    furniture.transform.SetParent(newParent);

        //furniture.transform.SetParent(newParent, false);

        //furniture.transform.SetParent(null);
    //}
}
