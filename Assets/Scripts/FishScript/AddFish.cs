using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class AddFish : MonoBehaviour
{
    public Fish fish;
    public void CatchFish()
    {
        Object();
        if (fish.small == true)
        {
            fish.FishWeight = Random.Range(1.00f, 6.00f);
            fish.FishValue = Mathf.FloorToInt(fish.FishWeight + fish.DefaultValue);
        }
        if (fish.medium == true)
        {
            fish.FishWeight = Random.Range(5.00f, 21.00f);
            fish.FishValue = Mathf.FloorToInt(fish.FishWeight + fish.DefaultValue);
        }
        if (fish.large == true)
        {
            fish.FishWeight = Random.Range(21.00f, 101.00f);
            fish.FishValue = Mathf.FloorToInt(fish.FishWeight + fish.DefaultValue);
        }
        Inventory.instance.AddFish(fish);
        Debug.Log("You Caught A " + fish.name + " This fish weighs " + fish.FishWeight.ToString("F2") + "LB");

        //var newfish = GetComponents<Fish>(fish.FishName, fish.FishDescription, fish.FishWeight, fish.icon);

        //var smallfish = GetComponentsInChildren<Fish>();
        //Inventory.instance.AddFish(smallfish);
        ////Inventory.instance.AddFish(fish);
    }

    public void Object()
    {
        Instantiate(fish);
    }
}

