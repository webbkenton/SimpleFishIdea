using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneMovement : MonoBehaviour
{

    public GameObject player;
    public GameObject NPC;
    public Animator animator;


    public void PlayScene()
    {
        if (player.transform.position != NPC.transform.position)
        {
            animator.SetFloat("Horizontal", 10f);
            animator.SetFloat("Speed", 5f);
            //player.transform.position = new Vector3(1,0,0);
        }
    }
 
}
