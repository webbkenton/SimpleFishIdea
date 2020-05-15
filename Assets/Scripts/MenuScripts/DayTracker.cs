using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTracker : MonoBehaviour
{
    public int dayCounter = 1;
    public int moonCounter;

    private void Update()
    {
        if (Clock.instance.day <= 1)
        {
            dayCounter = 1;
            moonCounter = 1;
        }
        if (Clock.instance.day <= 2 && Clock.instance.day > 1)
        {
            dayCounter = 2;
            moonCounter = 2;
        }
        if (Clock.instance.day <= 3 && Clock.instance.day > 2)
        {
            dayCounter = 3;
            moonCounter = 3;
        }
        if (Clock.instance.day <= 4 && Clock.instance.day > 3)
        {
            dayCounter = 4;
            moonCounter = 4;
        }
        if (Clock.instance.day <= 5 && Clock.instance.day > 4)
        {
            dayCounter = 1;
            moonCounter = 5;
        }
        if (Clock.instance.day <= 6 && Clock.instance.day > 5)
        {
            dayCounter = 2;
            moonCounter = 6;
        }
        if (Clock.instance.day <= 7 && Clock.instance.day > 6)
        {
            dayCounter = 3;
            moonCounter = 7;
        }
        if (Clock.instance.day <= 8 && Clock.instance.day > 7)
        {
            dayCounter = 4;
            moonCounter = 8;
        }
    }
}
