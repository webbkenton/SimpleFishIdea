using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyAfterWait : MonoBehaviour
{
    public GameObject Sparkle;

    void Start()
    {
        StartCoroutine(SelfDestruct());
        GameObject Pinky = GameObject.FindGameObjectWithTag("Player");
        Pinky.GetComponent<Animator>().enabled = false;
    }

    IEnumerator SelfDestruct()
    {
        Debug.Log("Begining");

        GameObject Pinky = GameObject.FindGameObjectWithTag("Player");
        yield return new WaitForSeconds(11f);
        Pinky.GetComponent<Animator>().enabled = true;
        this.transform.DetachChildren();
        Destroy(this.gameObject);
        Debug.Log("Ending");
        ResetPinky();
        //GameObject timeLineManager = GameObject.FindGameObjectWithTag("TimeLineManager");
        //timeLineManager.SetActive(false);
    }
    private void ResetPinky()
    {
        GameObject Pinky = GameObject.FindGameObjectWithTag("Player");
        ///Pinky.GetComponent<Animator>().enabled = true;
        Pinky.transform.position = new Vector2(0, 9.2f);
        ///Pinky.transform.position = Vector2.Lerp(Pinky.transform.position, new Vector2(0, 5.5f), 1);
        Pinky.transform.localScale = new Vector2(1, 1);

    }
}