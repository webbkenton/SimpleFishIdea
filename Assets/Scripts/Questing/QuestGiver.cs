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
    public bool PlayerInRange;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
        else 
        {
            PlayerInRange = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Questwindow.SetActive(false);
            PlayerInRange = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && PlayerInRange)
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
    public void AcceptQuest()
    {
        Questwindow.SetActive(false);
        quest.isActive = true;
        player.quest = quest;
    }

}