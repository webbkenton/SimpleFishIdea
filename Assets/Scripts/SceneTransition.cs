using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string sceneToLoad;
    public Vector2 PlayerPosition;
    public VectorValue PlayerLocale;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerLocale.initalValue = PlayerPosition;
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}
