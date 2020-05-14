using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExclamationMark : MonoBehaviour
{
    public GameObject ExclamationPoint;
    public GameObject ParentPool;
    public int ClickCounter;

    private void Update()
    {
        if (ParentPool.activeInHierarchy)
        {
            ExclamationPoint.SetActive(true);
        }
        if (!ParentPool.activeInHierarchy)
        {
            ExclamationPoint.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0) && ExclamationPoint.activeInHierarchy)
        {
            ClickCounter++;
            ExclamationPoint.SetActive(false);
        }
    }
    IEnumerator Exclamation()
    {
        yield return new WaitForSeconds(Random.Range(1, 5));
        Debug.Log("A");
    }
}
