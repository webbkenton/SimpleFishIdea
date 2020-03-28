using UnityEngine;
using UnityEngine.UI;

public class AddFish : MonoBehaviour
{
    public Fish fish;
    public void CatchFish()
    {
        Debug.Log("You Caught A " + fish.name);
        Inventory.instance.addfish(fish);
    }
    public void Hooked()
    {
        if (Input.GetButtonDown("CatchFish"))
        {
            CatchFish();
        }
    }
}


