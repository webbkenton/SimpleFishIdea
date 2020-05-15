using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class AddFish : MonoBehaviour
{
    public Fish fish;
    //public Fish newfish;
    public void CatchFish()
    {
        Fish clone = Instantiate(fish) as Fish;
         
        if (clone.small == true)
        {
            clone.FishWeight = Random.Range(1.00f, 5.00f);
            clone.FishValue = Mathf.FloorToInt(clone.FishWeight * fish.DefaultValue);
        }
        if (clone.medium == true)
        {
            clone.FishWeight = Random.Range(5.00f, 12.00f);
            clone.FishValue = Mathf.FloorToInt(clone.FishWeight * fish.DefaultValue);
        }
        if (clone.large == true)
        {
            clone.FishWeight = Random.Range(8.00f, 15.00f);
            clone.FishValue = Mathf.FloorToInt(clone.FishWeight * fish.DefaultValue) ;
        }
        if (clone.Legendary == true)
        {
            clone.FishWeight = Random.Range(10.00f, 25.00f);
            clone.FishValue = Mathf.FloorToInt(clone.FishWeight * fish.DefaultValue);
        }
        
        
        Inventory.instance.AddFish(clone);
        Debug.Log("You Caught A " + clone.name + " This fish weighs " + clone.FishWeight.ToString("F2") + "LB");
        
    }

    public void Object()
    {
        Fish clone = Fish.Instantiate(fish) as Fish;
        Debug.Log("Fish Instaniated");
    }
}

