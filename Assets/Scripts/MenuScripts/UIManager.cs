using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public bool shopwindow;
    public GameObject Shop;
    public Text dialogText;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject ContinueDialogButton;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(Type());
    }

    private void DialogBubble()
    {
       //Insert bouncing dialog bubble.
    }
    private IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void UpdateTyping()
    {
        dialogText.text = "";
        StartCoroutine(Type());
    }

    public void NextSentence()
    {
        ContinueDialogButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            dialogText.text = "";
            StartCoroutine(Type());
        }
        else
        {
            dialogText.text = "";
            ContinueDialogButton.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (dialogText.text == sentences[index])
        {
            ContinueDialogButton.SetActive(true);
        }
        if (Input.GetButtonDown("CloseShop"))
        {
            UIManager.instance.Shop.SetActive(!UIManager.instance.Shop.activeSelf);
        }
        if (Shop.activeInHierarchy)
        {
            shopwindow = true;
        }
        if (!Shop.activeInHierarchy)
        {
            shopwindow = false;
        }
    }
}
