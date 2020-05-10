using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{

    #region Singleton
    public static Clock instance;

    #endregion
    private Transform clockHourHandTransfrom;
    private Transform clockMinuteHandTransfrom;
    public TMP_Text dayOfTheWeek;
    public int dayCounter;
    public int moonCounter;


    private const float Real_Seconds = 720f;

    public float day;

    private void Awake()
    {
        instance = this;
        clockHourHandTransfrom = transform.Find("HourHand");
        clockMinuteHandTransfrom = transform.Find("MinuteHand");
    }
    void Update()
    {
        day += Time.deltaTime / Real_Seconds;

        if (Clock.instance.day <= 1)
        {
            dayOfTheWeek.text = "Mon";
            dayCounter = 1;
            moonCounter = 1;
        }
        if (Clock.instance.day <= 2 && Clock.instance.day > 1)
        {
            dayOfTheWeek.text = "Tue";
            dayCounter = 2;
            moonCounter = 2;
        }
        if (Clock.instance.day <= 3 && Clock.instance.day > 2)
        {
            dayOfTheWeek.text = "Wed";
            dayCounter = 3;
            moonCounter = 3;
        }
        if (Clock.instance.day <= 4 && Clock.instance.day > 3)
        {
            dayOfTheWeek.text = "Thur";
            dayCounter = 4;
            moonCounter = 4;
        }
        if (Clock.instance.day <= 5 && Clock.instance.day > 4)
        {
            dayOfTheWeek.text = "Mon";
            dayCounter = 1;
            moonCounter = 5;
        }
        if (Clock.instance.day <= 6 && Clock.instance.day > 5)
        {
            dayOfTheWeek.text = "Tue";
            dayCounter = 2;
            moonCounter = 6;
        }
        if (Clock.instance.day <= 7 && Clock.instance.day > 6)
        {
            dayOfTheWeek.text = "Wed";
            dayCounter = 3;
            moonCounter = 7;
        }
        if (Clock.instance.day <= 8 && Clock.instance.day > 7)
        {
            dayOfTheWeek.text = "Thur";
            dayCounter = 4;
            moonCounter = 8;
        }
        if (day > 8)
        {
            day = 0;
        }

        float dayNormalized = day % 1f;
        float RotationDegrees = 360f;
        clockHourHandTransfrom.eulerAngles = new Vector3(0, 0, -dayNormalized * RotationDegrees);

        float hoursPerDay = 24f;
        clockMinuteHandTransfrom.eulerAngles = new Vector3(0, 0, -dayNormalized * RotationDegrees * hoursPerDay);

    }
}
