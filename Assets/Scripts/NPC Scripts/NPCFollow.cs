using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    public bool Follow;
    public float Speed;
    public float StoppingDistance;
    private Transform Target;


    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if (Follow == true)
        {
            if (Vector2.Distance(transform.position, Target.position) > StoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
            }
        }
    }

    public void followButton()
    {
        Follow = true;
    }
}
