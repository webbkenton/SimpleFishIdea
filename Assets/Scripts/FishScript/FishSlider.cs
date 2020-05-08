using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishSlider : MonoBehaviour
{
    public static FishSlider instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More then 1");
            return;
        }
        instance = this;
    }
    FishSlider FishingSlider;
    public Slider fishSlider;
    public bool Fishing = true;
    public bool FishCaught = false;
    public int RandomNumberFish;
    public bool Clickable;
    public int Counter;
    public bool ReelIn;
    public GameObject ClickToReel;



    // Start is called before the first frame update
    void Start()
    {
        FishingSlider = FishSlider.instance;
        fishSlider.interactable = false;
        fishSlider.minValue = 0;
        fishSlider.maxValue = 100;
        fishSlider.wholeNumbers = false;
        fishSlider.value = 0;
        RandomNumberFish = Random.Range(0, 100);

        //StartCoroutine(FishMovement());


    }

    // Update is called once per frame
    void Update()
    {
        MoveFish();
        if (Counter >= 5)
        {
            fishSlider.value = 100;
            ReelIn = true;
        }
        if (ReelIn == true)
        {
            ClickToReel.SetActive(true);
        }
        
    }

    private void MoveFish()
    {
        StartCoroutine(FishMovement());
        if (fishSlider.value != RandomNumberFish)
        {
            fishSlider.value = Mathf.MoveTowards(fishSlider.value, RandomNumberFish, .1f);
        }
        if (fishSlider.value == RandomNumberFish)
        {
            Clickable = true;       
        }
        
    }

    IEnumerator FishMovement()
    {
        yield return new WaitForSeconds(5);
    }

    public void CatchingFish()
    {
        Counter += 1;
        Clickable = false;
        RandomNumberFish = Random.Range(0, 100);
    }
    public void ResetFish()
    {
        ReelIn = false;
        Counter = 0;
        Fishing = false;
        fishSlider.value = 0;
        ClickToReel.SetActive(false);
    }
}
