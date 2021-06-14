using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneProgressTracker : MonoBehaviour
{
    public float MockDeaths;
    public List<Transform> transforms;
    public List<Animator> animators;
    private GameObject Golem;
    private Vector2 Middle;
    // Start is called before the first frame update
    void Start()
    {
        Golem = GameObject.FindGameObjectWithTag("Golem");
        Golem.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (MockDeaths >= 3)
            StartCoroutine(MoveMocks());
            //Golem.SetActive(true);
    }

    private void SpawnGolem()
    {
        Golem.SetActive(true);
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("DeadEnemy");
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(false);
        }
    }
    private IEnumerator MoveMocks()
    {
        foreach (Animator animator in animators)
        {
            if (animator.isActiveAndEnabled)
            {
                animator.Play("MockDustTwirl");
            }
        }
        foreach (Transform transform in transforms)
        {
            transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, Time.deltaTime);
        }
        yield return new WaitForSeconds(5f);
        SpawnGolem();
    }

    public void UpdateMockDeaths()
    {
        MockDeaths++;
    }

}
