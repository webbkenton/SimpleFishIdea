using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class AddFish : MonoBehaviour
{
    public Fish fish;
    public void CatchFish()
    {
        Object();
        Debug.Log("You Caught A " + fish.name);
        Inventory.instance.AddFish(fish);
        
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

