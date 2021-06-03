using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;
    public float smoothing;

    public Vector2 maxPosition;
    public Vector2 minPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
            //if (minPosition.x > -4.4f)
            //{
             //   minPosition.x = 28.45f;
               // minPosition.y = -2.6f;
                //maxPosition.x = 36.6f;
                //maxPosition.y = 2.3f;
                //targetPosition = new Vector3(target.position.x, targetPosition.y, transform.position.z);
           // }
            //if (targetPosition.x < 20.45f)
            //{
              //  minPosition.x =-4.4f;
               // minPosition.y =-6f;
                //maxPosition.x =4.45f;
                //maxPosition.y =4.85f;
            }
       // }
    }
}