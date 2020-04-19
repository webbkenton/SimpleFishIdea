using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform playerTransform;


    //private void Update()
    //{
    //    if (Input.GetButtonDown("PickUp"))
    //    {
    //        itemPrefab.transform.position = playerTransform.position;
    //    }
    //}
    public void InstantiateItem()
    {
        Instantiate(itemPrefab);
        //itemPrefab.transform.SetParent(null);
      
        

    }
}
