using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerStats 
{
  
   
    public Vector2 Direction {get; set;}

    public float Speed {get; set;}
    // -----------------------------------------------------------------------
    [SerializeField]
    private float walkSpeed;

    public float WalkSpeed     
    { 
        get
        {
            return walkSpeed; 
        }
    }

    // -----------------------------------------------

    [SerializeField]
    private float runSpeed;

        public float RunSpeed     
    { 
        get
        {
            return runSpeed; 
        }
    }
}
