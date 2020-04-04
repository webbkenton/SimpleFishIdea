using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private Transform clockHourHandTransfrom;
    private Transform clockMinuteHandTransfrom;

    private const float Real_Seconds = 720f;

    private float day;

    private void Awake()
    {
        clockHourHandTransfrom = transform.Find("HourHand");
        clockMinuteHandTransfrom = transform.Find("MinuteHand");
    }
    void Update()
    {
        day += Time.deltaTime / Real_Seconds;

        float dayNormalized = day % 1f;
        float RotationDegrees = 360f;
        clockHourHandTransfrom.eulerAngles = new Vector3(0, 0, -dayNormalized * RotationDegrees);

        float hoursPerDay = 24f;
        clockMinuteHandTransfrom.eulerAngles = new Vector3(0, 0, -dayNormalized * RotationDegrees * hoursPerDay);

    }
}
