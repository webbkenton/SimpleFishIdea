using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MouseHover : MonoBehaviour
{
    public GameObject informationBox;
    public bool ItemHover;

    public void InformationboxOn()
    {
        informationBox.SetActive(true);
    }

    public void InformationboxOff()
    {
        informationBox.SetActive(false);
    }
}
