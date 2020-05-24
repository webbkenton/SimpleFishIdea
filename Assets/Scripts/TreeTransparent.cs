using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTransparent : MonoBehaviour
{
    private SpriteRenderer Spriter;
    private Color StartingColor;
    private float full;
    private float forty;
    
    // Start is called before the first frame update
    void Start()
    {
        full = 100;
        forty = 40;

        Spriter = this.GetComponent<SpriteRenderer>();
        StartingColor = Spriter.color;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Spriter.color = new Color(Spriter.color.r, Spriter.color.g, Spriter.color.b, .4f);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Spriter.color = new Color(Spriter.color.r, Spriter.color.g, Spriter.color.b, .4f);

        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Spriter.color = StartingColor;
        }
    }
}
