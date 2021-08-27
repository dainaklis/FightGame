using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConrol2D : MonoBehaviour
{
    

    Animator animator;
    Rigidbody2D rigi2D;
    SpriteRenderer spriteRenderer;

    
    bool isGrounded;
    
    
    [SerializeField] 
    Transform groundChech; //parodo SCRIPT faile

    [SerializeField]  float runSpeed = 3;
    [SerializeField]  float jumpSpeed = 6;


    void Start()
    {
        animator = GetComponent<Animator>();
        rigi2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate() 
    {
        if(Physics2D.Linecast(transform.position, groundChech.position, 1 << LayerMask.NameToLayer("ground")))
            
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }


        if(Input.GetKey("d") || Input.GetKey("right")){
            rigi2D.velocity = new Vector2(runSpeed, rigi2D.velocity.y);

            if(isGrounded)
            {
                animator.Play("Run");
                spriteRenderer.flipX = true;
            }


        }
        else if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rigi2D.velocity = new Vector2(-runSpeed, rigi2D.velocity.y);

            if(isGrounded)
            {
                animator.Play("Run");
                spriteRenderer.flipX = false;
            }
        }

        else if(Input.GetKey("z"))
        {
            if(isGrounded)
            {
                animator.Play("shoot");
            }
            
            
        }

        else{

            if(isGrounded)
            {
                animator.Play("Idle");
                rigi2D.velocity = new Vector2(0, rigi2D.velocity.y);
            }
        }

        if(Input.GetKey("space") && isGrounded )
        {
            rigi2D.velocity = new Vector2(rigi2D.velocity.x, jumpSpeed);
        }


    }
   
}
