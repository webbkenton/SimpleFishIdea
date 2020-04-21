using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public GameObject StartMenu;

    //public void Start()
    //{
    //    StartMenu.SetActive(true)
    //}

    public void CloseApllication()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        SceneManager.LoadScene("House");
    }

}
