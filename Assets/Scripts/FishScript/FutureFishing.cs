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
    public GameObject FishPool;
    //public float RandomPoolDecision;


    void Update()
    {
        if (FishPool.activeInHierarchy)
        {
            InRange = true;
        }
        else
        {
            InRange = false;
        }
            //Play the fishing game
            //OnLastClick choose a number (0-1)
            //#>.25 pull fish from common pull
            //if #<.25 but #>.1 pull from uncommon pull
            
        if (Input.GetMouseButtonDown(0) && FishSlider.instance.ReelIn == true && InRange == true)
        {
            var allAddFish = GetComponentsInChildren<AddFish>();
            var selectedIndex = Random.Range(0, allAddFish.Length);
            AddFish selectedObject = allAddFish[selectedIndex];
            selectedObject.CatchFish();
            FishingSlider.SetActive(false);
            FishPool.SetActive(false);
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
