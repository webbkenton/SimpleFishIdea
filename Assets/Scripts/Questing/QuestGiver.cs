using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    public Player player;

    public GameObject Questwindow;
    public Text titleText;
    public TMP_Text DescriptionText;
    public TMP_Text GoldText;
    public TMP_Text RequiredItemText;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OpenQuestWindow();
        }
    }
    public void OpenQuestWindow()
    {
        Questwindow.SetActive(true);
        titleText.text = quest.title;
        DescriptionText.text = quest.description;
        GoldText.text = quest.goldReward.ToString();
        RequiredItemText.text = quest.requiredItem;

    }

}