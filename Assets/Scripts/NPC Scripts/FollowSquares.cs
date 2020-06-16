using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSquares : MonoBehaviour
{

    public GameObject Square1;
    public GameObject Square2;
    public Transform StartingPlayerPosition;
    private Transform PlayerMovedPosition;
    private Transform FollowSquarePosition;
    public bool following;

    private void Start()
    {
        PlayerMovedPosition.position =StartingPlayerPosition.position;
        Square1.transform.position = StartingPlayerPosition.position;
        Square2.transform.position = StartingPlayerPosition.position;
    }
    void Update()
    {
        
        if (following == true)
        {
            
        }
    }
}
