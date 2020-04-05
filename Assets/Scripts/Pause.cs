using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class Pause : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public GameObject SettingsMenuUI;

    public void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            PauseMenuUI.SetActive(!PauseMenuUI.activeSelf);
        }
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Closing The Game");
    }

    public void ResumeGame()
    {
        PauseMenuUI.SetActive(false);
    }
    public void SettingsMenu()
    {
        PauseMenuUI.SetActive(false);
        SettingsMenuUI.SetActive(true);
    }
    public void BackMenu()
    {
        SettingsMenuUI.SetActive(false);
        PauseMenuUI.SetActive(true);

    }
}
