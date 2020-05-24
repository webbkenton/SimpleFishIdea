using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosetSpace : MonoBehaviour
{
    private int closetSpace = 20;
    public int currentSpace;
    private int Upgrades;
    private int nextSpace;
    public int nextCost = 1000;
    public Button Costbutton;
    public Text CostText;
    public Text SpaceText;
    public List<FurnitureScriptableObject> closetFurniture = new List<FurnitureScriptableObject>();

    private void Start()
    {
        currentSpace = closetSpace;
        nextSpace = currentSpace + 20;
    }
    private void Update()
    {
        if (CurrencyManager.instance.CurrentGold < nextCost)
        {
            Costbutton.interactable = false;
        }
        else
        {
            Costbutton.interactable = true;
        }
        CostText.text = nextCost.ToString();
        SpaceText.text = closetSpace.ToString();
    }
    public void MoreSpace()
    {
        CurrencyManager.instance.CurrentGold -= nextCost;
        Upgrades++;
        closetSpace += 20;
        nextSpace += 20;
        nextCost += nextCost;
        Debug.Log(nextCost + "NextCost");
        Debug.Log(closetSpace + "ClosetSpace");
        Debug.Log(nextSpace + "nextSpace");
    }
}
