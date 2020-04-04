using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CurrencyManager : MonoBehaviour
{

    public TMP_Text CurrencyText;
    public int CurrentGold;

    public int MaximumGold = 9999999;
    public int MinimumGold = 0;
    // Start is called before the first frame update
    void Start()
    {

        CurrentGold = 0;
        CurrencyText.text = CurrentGold.ToString();
        
    }

    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.N))
        {
            CurrentGold += 20;
        }
        if (CurrencyText.text != CurrentGold.ToString())
        {
            CurrencyText.text = CurrentGold.ToString();
        }
        if (CurrentGold >= MaximumGold)
        {
            CurrentGold = MaximumGold;

        }
        if (Input.GetKey(KeyCode.M))
        {
            CurrentGold -= 20;
            if (CurrentGold < MinimumGold)
            {
                CurrentGold = MinimumGold;
            }
        }
        
    }
    //public void AddGold(int goldToAdd)
    //{
    //    CurrentGold += goldToAdd;
    //}
}
