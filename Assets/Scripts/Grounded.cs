﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject Player;
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.collider.tag == "Ground")
        {
            Player.GetComponent<Moved>().isGrounded = true;
        }
       
    }
    void OnCollisionExit2D(Collision2D collision) 
     {
        if(collision.collider.tag == "Ground")
        {
            Player.GetComponent<Moved>().isGrounded = false;
        }
    }
}

