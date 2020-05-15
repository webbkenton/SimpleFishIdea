using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishingSceneTransfer : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 PlayerPosition;
    public VectorValue PlayerLocale;
    public float Transitiontime = 3f;
    public Animator TransitionAnimation;
    public GameObject TransferPanel;
    public bool amFish;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            amFish = true;
            FirstPerson();
        }
        if (Input.GetButtonDown("CatchFish") && amFish == true)
        {
            FirstPerson();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            amFish = true;
            PlayerLocale.initalValue = this.transform.position;
        }
    }
    IEnumerator LoadLevel()
    {
        TransitionAnimation.SetTrigger("Start");

        yield return new WaitForSeconds(Transitiontime);
        SceneManager.LoadScene(sceneToLoad);

    }

    public void FirstPerson()
    {
        TransferPanel.SetActive(true);
        TransitionAnimation.SetTrigger("Start");
        PlayerLocale.initalValue = PlayerPosition;
        PlayerLocale.defaultValue = PlayerPosition;
        //SceneManager.LoadScene(sceneToLoad);
        StartCoroutine(LoadLevel());
    }
}
