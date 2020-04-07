using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int currency;
    public GameObject inventory;


    private void Update()
    {
        currency = CurrencyManager.instance.CurrentGold;
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        currency = data.currency;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
        CurrencyManager.instance.CurrentGold = data.currency;

    }

    
}
