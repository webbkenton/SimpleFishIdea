using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string sceneToLoad;
    public Vector2 PlayerPosition;
    public VectorValue PlayerLocale;
    public float Transitiontime = 3f;
    public Animator TransitionAnimation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TransitionAnimation.SetTrigger("Start");
            PlayerLocale.initalValue = PlayerPosition;
            //SceneManager.LoadScene(sceneToLoad);
            StartCoroutine(LoadLevel());
        }
    }
    IEnumerator LoadLevel()
    {
       TransitionAnimation.SetTrigger("Start");

       yield return new WaitForSeconds(Transitiontime);
       SceneManager.LoadScene(sceneToLoad);

    }

}
