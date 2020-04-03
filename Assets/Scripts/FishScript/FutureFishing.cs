using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FutureFishing : MonoBehaviour
{

    public GameObject exclamationMark;
    public GameObject FishingPrompt;
    public bool InRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("CatchFish") && CompareTag("FishingSpot"))
        {
            if (InRange == true)
            {
                var allAddFish = GetComponentsInChildren<AddFish>();
                var selectedIndex = Random.Range(0, allAddFish.Length);
                AddFish selectedObject = allAddFish[selectedIndex];
                selectedObject.CatchFish();

                exclamationMark.SetActive(false);
            }
        }
        if (Input.GetButtonDown("Fishing"))
        {
            if (InRange == true)
            {
                FishingPrompt.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InRange = false;
            FishingPrompt.SetActive(false);
        }
    }

    public void FishingPrompter()
    {
        FishingPrompt.SetActive(false);
    }
//    public void FreeFish()
//    {
//        Debug.Log("You Caught A " + fish.name);
//        Inventory.instance.addfish(fish);
//    }
}
