using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FutureFishing : MonoBehaviour
{

    //public GameObject exclamationMark;
    //public GameObject FishingPrompt;
    public bool InRange;
    public GameObject FishingSlider;
    void Update()
    {
        if (Input.GetButtonDown("CatchFish") && InRange == true)
        {
            FishingSlider.SetActive(true);
        }
        if (Input.GetMouseButtonDown(0) && FishSlider.instance.ReelIn == true)
        {
            var allAddFish = GetComponentsInChildren<AddFish>();
            var selectedIndex = Random.Range(0, allAddFish.Length);
            AddFish selectedObject = allAddFish[selectedIndex];
            selectedObject.CatchFish();
            FishingSlider.SetActive(false);
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
            FishingSlider.SetActive(false);
        }
    }

    //public void FishCaught()
    //{
    //    if (FishSlider.instance.ReelIn == true)
    //    {   
    //        var allAddFish = GetComponentsInChildren<AddFish>();
    //        var selectedIndex = Random.Range(0, allAddFish.Length);
    //        AddFish selectedObject = allAddFish[selectedIndex];
    //        selectedObject.CatchFish();
    //    }
        

    //    FishingSlider.SetActive(false);
    //}
}
