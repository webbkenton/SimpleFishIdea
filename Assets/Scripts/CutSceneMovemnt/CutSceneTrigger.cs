using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class CutSceneTrigger : MonoBehaviour
{
    public int Counter;
    public bool inRange;
    public GameObject CutTrigger;
    public PlayableDirector timeline;
    void Update()
    {
        if (Counter >= 1)
        {
            CutTrigger.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timeline.Play();
            Counter++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Counter++;
        }
    }
}
