using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReparentCamera : MonoBehaviour
{
    private bool Hasrun;
    //private bool CompleteRun;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CameraParent");
    }
    private void Update()
    {
        if (Hasrun && Camera.main.GetComponent<CameraMovement>().enabled == false)
        {
            Camera.main.GetComponent<CameraMovement>().enabled = true;
        }
    }
    private IEnumerator CameraParent()
    {
        Debug.Log("Started");
        Camera.main.GetComponent<CameraMovement>().enabled = false;
        yield return new WaitForSeconds(15f);
        Hasrun = true;
        Debug.Log("Finish");
        
    }

    private void PinkyCamera()
    {
        GameObject Pinky = GameObject.FindGameObjectWithTag("Player");
        GameObject Cam = GameObject.FindGameObjectWithTag("Camera");
        Camera.main.transform.position = new Vector3(Pinky.transform.position.x, Pinky.transform.position.y, -7);
        //CompleteRun = true;
    }
}
