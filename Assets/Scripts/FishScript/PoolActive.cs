using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PoolActive : MonoBehaviour
{
    public bool Day;
    public bool Night;
    //public int ClickCount;
    public int ClickCounter;
    public int RequiredAmount;
    public float RandomChance;
    public AudioSource audio;
    public GameObject CommonDay;
    public GameObject CommonNight;
    public GameObject UncommonDay;
    public GameObject UncommonNight;
    public GameObject RareDay;
    public GameObject RareNight;
    public GameObject ExclamationPoint;
    private GameObject FishPool;


    private void Start()
    {
        ExclamationPoint.SetActive(false);
    }
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
        if (Input.GetMouseButtonDown(0))
        {
            if ( !ExclamationPoint.activeInHierarchy)
            {
                StopAllCoroutines();
                ExclamationPoint.SetActive(false);
                ClickCounter = 0;
                RandomChance = 0;
                RequiredAmount = 0;
                Debug.Log("EarlyClick");
            }
            //ClickCount++;
            if (ExclamationPoint.activeInHierarchy)
            {

                ClickCounter++;
                if (ClickCounter >= RequiredAmount)
                {
                    Catching();
                    audio.Play();
                }
                if (ClickCounter <= RequiredAmount - 2)
                {
                    ExclamationPoint.SetActive(false);
                    StartCoroutine(TrippleTime());
                }
                if (ClickCounter <= RequiredAmount - 1)
                {
                    ExclamationPoint.SetActive(false);
                    StartCoroutine(DoubleTime());
                }
            }
          
        }
        //if (Input.GetMouseButtonDown(0) && Pool == false)
        //{
        //    FishPool.SetActive(false);
        //    StopCoroutine(Quicktime());
        //    ExclamationPoint.SetActive(false);
        //    RandomChance = 0;
        //    RequiredAmount = 0;
        //    Debug.Log("EarlyClick");
        //}
        if (Input.GetButtonDown("CatchFish"))
        {
            StopAllCoroutines();
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
        Debug.Log("QuickTime!");
        yield return new WaitForSeconds(Random.Range(1, 5));
        ExclamationPoint.SetActive(true);
        yield return new WaitForSeconds(Random.Range(1, 5));
        ExclamationPoint.SetActive(false);
        FishPool.SetActive(false);
    }
    IEnumerator DoubleTime()
    {
        Debug.Log("DoubleTime!");
        StopCoroutine(Quicktime());
        //ExclamationPoint.SetActive(false);
        yield return new WaitForSeconds(Random.Range(1, 4));
        ExclamationPoint.SetActive(true);
        yield return new WaitForSeconds(Random.Range(1, 4));
        ExclamationPoint.SetActive(false);
        //Catching();
        FishPool.SetActive(false);
    }
    IEnumerator TrippleTime()
    {
        Debug.Log("TrippleTime!!!");
        StopCoroutine(Quicktime());
        ExclamationPoint.SetActive(false);
        yield return new WaitForSeconds(Random.Range(1, 3));
        ExclamationPoint.SetActive(true);
        yield return new WaitForSeconds(Random.Range(1, 3));
        ExclamationPoint.SetActive(false);
        //Catching();
        FishPool.SetActive(false);
    }
}
