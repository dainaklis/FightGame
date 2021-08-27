using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementAndroid : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove;
    [SerializeField] private float speedMove;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveLeft = false;
        moveRight = false;
    }

    public void PointerDownLeft()
    {
        moveLeft = true;
    }
    public void PointerUpLeft()
    {
       moveLeft = false; 
    }

    public void PointerDownRight()
    {
        moveRight = true;
    }
    public void PointerUpRight()
    {
       moveRight = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Movement()
    {
        if (moveLeft)
        {
            horizontalMove = -speedMove;
        }

        else if (moveRight)
        {
            horizontalMove = speedMove;
        }
        else
        {
            horizontalMove = 0;
        }
    }

    private void FixedUpdate() 
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }

    public void TestAttack()
    {
        Debug.Log("TEST");
    }
}
