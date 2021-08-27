using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Control : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigi2D;
    SpriteRenderer spriteRenderer;

    bool isGrounded;

    // //saudo----------------------------------------------------------------
    Object bulletRef;
    
    [SerializeField] 
    float xPos = 2f;

    [SerializeField] 
    float yPos = 1f;
    //-------------------------------------------------------------------------
    
    [SerializeField] Transform groundChech; //parodo SCRIPT faile

    [SerializeField] Transform groundChechR;
    [SerializeField] Transform groundChechL;
    
    [SerializeField]  float runSpeed = 3;
    [SerializeField]  float jumpSpeed = 6;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigi2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //saudo-----------------------------------------------------------

        bulletRef = Resources.Load("fire");
        animator = GetComponent<Animator>();
       // ------------------------------------------------------------------------
    }

    // Update is called once per frame
    private void FixedUpdate() 
    {

        if((Physics2D.Linecast(transform.position, groundChech.position, 1 << LayerMask.NameToLayer("ground"))) ||
            (Physics2D.Linecast(transform.position, groundChechR.position, 1 << LayerMask.NameToLayer("ground"))) ||
            (Physics2D.Linecast(transform.position, groundChechL.position, 1 << LayerMask.NameToLayer("ground"))))
            
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            animator.Play("player_jump");
            
        }



        if(Input.GetKey("l") || Input.GetKey("right"))
        {
            rigi2D.velocity = new Vector2(runSpeed, rigi2D.velocity.y);

            if(isGrounded)
            {
                animator.Play("player_run");
                spriteRenderer.flipX = false;
            }


        }
        else if(Input.GetKey("j") || Input.GetKey("left"))
        {
            rigi2D.velocity = new Vector2(-runSpeed, rigi2D.velocity.y);

            if(isGrounded)
            {
                animator.Play("player_run");
                spriteRenderer.flipX = true;
            }

        }

        //saudo--------------------------------------------------------------------
        //pakeiciau is ---- if(Input.GetButtonDown("Fire1")) ------------------
        
        else if(Input.GetKey("k") || Input.GetButtonDown("Fire1"))
        {
            if(isGrounded)
            {
            animator.Play("player_shoot");
            GameObject bullet = (GameObject)Instantiate(bulletRef);
            bullet.transform.position = new Vector3(transform.position.x + xPos, transform.position.y + yPos, -1);
            }
            
        }

        //------------------------------------------------------------------------------

        else
        {

            if(isGrounded)
            {
            animator.Play("Player_Idle");
            rigi2D.velocity = new Vector2(0, rigi2D.velocity.y); 
            }
            
        }

        if(Input.GetKey("i") && isGrounded)
        {
            rigi2D.velocity = new Vector2(rigi2D.velocity.x, jumpSpeed);
            animator.Play("player_jump");
            GetComponent<AudioSource>().Play();
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();  
        }


        
    }
}
