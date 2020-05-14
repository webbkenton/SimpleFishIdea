using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolActive : MonoBehaviour
{
    public bool Day;
    public bool Night;
    public int ClickCounter;
    public int RequiredAmount;
    public float RandomChance;
    public GameObject CommonDay;
    public GameObject CommonNight;
    public GameObject UncommonDay;
    public GameObject UncommonNight;
    public GameObject RareDay;
    public GameObject RareNight;
    public GameObject ExclamationPoint;
    private GameObject FishPool;

    void Update()
    {
        if (Clock.instance.day <= .5f)
        {
            Day = true;
            Night = false;
        }
        else
        {
            Night = true;
            Day = false;
        }
        if (Input.GetMouseButtonDown(0) && ExclamationPoint.activeInHierarchy)
        {
            ClickCounter++;
            if (ClickCounter >= RequiredAmount)
            {
                Catching();
            }
            else
            {
                StartCoroutine(Quicktime());
            }
        }
        if (Input.GetButtonDown("CatchFish"))
        {
            RandomChance = Random.Range(0.00f, 1.00f);
            StartCoroutine(Quicktime());
            if (RandomChance <= .15f && RandomChance > .01)
            {
                CommonDay.SetActive(false);
                CommonNight.SetActive(false);
                RareDay.SetActive(false);
                RareNight.SetActive(false);
                //ExclamationPoint.SetActive(true);

                if (Day == true)
                {
                    UncommonDay.SetActive(true);
                    FishPool = UncommonDay;
                    RequiredAmount = 2;
                    
                }
                if (Night == true)
                {
                    UncommonNight.SetActive(true);
                    FishPool = UncommonNight;
                    RequiredAmount = 2;

                }
                else
                {
                    return;
                }
            }
            if (RandomChance <= .01f)
            {
                CommonDay.SetActive(false);
                CommonNight.SetActive(false);
                UncommonDay.SetActive(false);
                UncommonNight.SetActive(false);
                //ExclamationPoint.SetActive(true);

                if (Day == true)
                {
                    RareDay.SetActive(true);
                    FishPool = RareDay;
                    RequiredAmount = 3;
                }
                if (Night == true)
                {
                    RareNight.SetActive(true);
                    FishPool = RareNight;
                    RequiredAmount = 3;
                }
                else
                {
                    return;
                }
            }
            if (RandomChance >= .15f)
            {
                UncommonDay.SetActive(false);
                UncommonNight.SetActive(false);
                RareDay.SetActive(false);
                RareNight.SetActive(false);
                //ExclamationPoint.SetActive(true);

                if (Day == true)
                {
                    CommonDay.SetActive(true);
                    FishPool = CommonDay;
                    RequiredAmount = 1;
                }
                if (Night == true)
                {
                    CommonNight.SetActive(true);
                    FishPool = CommonNight;
                    RequiredAmount = 1;
                }
                else
                {
                    return;
                }
            }
   
        }

    }
    private void Catching()
    {
        Debug.Log("Caught");
        var allAddFish = FishPool.GetComponentsInChildren<AddFish>();
        var selectedIndex = Random.Range(0, allAddFish.Length);
        AddFish selectedObject = allAddFish[selectedIndex];
        selectedObject.CatchFish();
        ClickCounter = 0;
        RequiredAmount = 0;
        FishPool.SetActive(false);
        ExclamationPoint.SetActive(false);
    }
    IEnumerator Quicktime()
    {
        yield return new WaitForSeconds(Random.Range(1, 5));
        ExclamationPoint.SetActive(true);
        yield return new WaitForSeconds(Random.Range(1, 5));
        ExclamationPoint.SetActive(false);
    }
}
