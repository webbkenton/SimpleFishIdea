using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolActive : MonoBehaviour
{

    public bool InRange;
    public bool Day;
    public bool Night;
    public float RandomChance;
    public GameObject FishingSlider;
    public GameObject CommonDay;
    public GameObject CommonNight;
    public GameObject UncommonDay;
    public GameObject UncommonNight;
    public GameObject RareDay;
    public GameObject RareNight;

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
        if (Input.GetButtonDown("CatchFish") && InRange == true)
        {
            RandomChance = Random.Range(0.00f, 1.00f);
            if (RandomChance <= .15f && RandomChance > .01)
            {
                if (Day == true)
                {
                    UncommonDay.SetActive(true);
                    FishingSlider.SetActive(true);
                }
                if (Night == true)
                {
                    UncommonNight.SetActive(true);
                    FishingSlider.SetActive(true);

                }
                else
                {
                    return;
                }
            }
            if (RandomChance <= .01f)
            {
                if (Day == true)
                {
                    RareDay.SetActive(true);
                    FishingSlider.SetActive(true);
                }
                if (Night == true)
                {
                    RareNight.SetActive(true);
                    FishingSlider.SetActive(true);
                }
                else
                {
                    return;
                }
            }
            if (RandomChance >= .15f)
            {
                if (Day == true)
                {
                    CommonDay.SetActive(true);
                    FishingSlider.SetActive(true);
                }
                if (Night == true)
                {
                    CommonNight.SetActive(true);
                    FishingSlider.SetActive(true);
                }
                else
                {
                    return;
                }
            }
        }
        if (!FishingSlider.activeInHierarchy && RandomChance != 0f)
        {
            RandomChance = 0f;
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
        }
    }
}
