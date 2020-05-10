using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectWallFurniture : MonoBehaviour
{
    public Collider2D wallCollider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WallFurniture"))
        {
            wallCollider.enabled = false;
        }
    }
}
