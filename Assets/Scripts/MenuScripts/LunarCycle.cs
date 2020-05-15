using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LunarCycle : MonoBehaviour
{
    public GameObject Lunar1;
    public GameObject Lunar2;
    public GameObject Lunar3;
    public GameObject Lunar4;
    public GameObject Lunar5;
    public GameObject Lunar6;
    public GameObject Lunar7;
    public GameObject Lunar8;

    void Update()
    {
        if (Clock.instance.moonCounter == 1)
        {
            Lunar1.SetActive(true);
        }
        else
        {
            Lunar1.SetActive(false);
        }
        if (Clock.instance.moonCounter == 2)
        {
            Lunar2.SetActive(true);
        }
        else
        {
            Lunar2.SetActive(false);
        }
        if (Clock.instance.moonCounter == 3)
        {
            Lunar3.SetActive(true);
        }
        else
        {
            Lunar3.SetActive(false);
        }
        if (Clock.instance.moonCounter == 4)
        {
            Lunar4.SetActive(true);
        }
        else
        {
            Lunar4.SetActive(false);
        }
        if (Clock.instance.moonCounter == 5)
        {
            Lunar5.SetActive(true);
        }
        else
        {
            Lunar5.SetActive(false);
        }
        if (Clock.instance.moonCounter == 6)
        {
            Lunar6.SetActive(true);
        }
        else
        {
            Lunar6.SetActive(false);
        }
        if (Clock.instance.moonCounter == 7)
        {
            Lunar7.SetActive(true);
        }
        else
        {
            Lunar7.SetActive(false);
        }
        if (Clock.instance.moonCounter == 8)
        {
            Lunar8.SetActive(true);
        }
        else
        {
            Lunar8.SetActive(false);
        }
    }
}
