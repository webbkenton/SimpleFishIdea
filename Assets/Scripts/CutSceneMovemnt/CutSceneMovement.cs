using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneMovement : MonoBehaviour
{
    public Animator animator;
    public float left = -10f;
    public float right = 7f;
    static float start = 0f;

    private void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(left, right, start), 0, 0);
        start += 0.1f * Time.deltaTime;

        animator.SetFloat("Horizontal", 0.1f);
        animator.SetFloat("Speed", transform.position.sqrMagnitude);
        
        if (transform.position.x >= 7f)
        {
            animator.SetFloat("Speed", 0f);
        }
    }
}
