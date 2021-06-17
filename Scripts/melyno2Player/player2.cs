using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;


public class player2 : MonoBehaviour
{   

    private Rigidbody2D rb;
    private Animator anim;
    private enemy Enemy;

    //Walk
    private float moveDirection;
    public float moveSpeed;

    private bool isWalk;

    //Jump and (GroundCheck(is Antarsoft))
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer;


    //Flip
    private bool isFacingRight = true;

    //Atack
    private bool isKick;
    private bool isPunch;
    [SerializeField] private GameObject bloodPlayer;

    

    [SerializeField] GameObject attackHitBox;
    [SerializeField] GameObject attackKickBox;




    // HEALTH Bar BARCKEYS
    [SerializeField]  private int maxHealth = 100;

    [SerializeField]  private int currentHealth;

    [SerializeField]  private  healthBar healthBar;


    //You LOSE Bar
    [SerializeField] private GameObject loseText;
    [SerializeField] private float waitTime;
 

    //Sound
    [SerializeField] private AudioSource soundAttack, soundHit, soundDead;

    private    int a = 2;
    private   int c;
    private   int c1;
    
    





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        attackHitBox.SetActive(false);
        attackKickBox.SetActive(false);




    }

    // Update is called once per frame
    void Update()
    {   

        //Test PLAYER HEALTBAR
        if (Input.GetKeyDown("m"))
        {
            TakeDamage(20);
            soundDead.Play();
            AttackPunchButton();
         
        }



        if (currentHealth <= 0)
        {   
            //GetComponent<Collider2D>().enabled = false;
            //neveikia
            //soundDead.Play();

            //this.enabled = false;

            StartCoroutine(LoseAndLoad());
        }


        IEnumerator LoseAndLoad()
        {   
            // GetComponent<player2>().enabled = false;

            anim.Play("player2Dead");
            yield return new WaitForSeconds(waitTime);

            Destroy(gameObject, 3);

            loseText.SetActive(true);
            yield return new WaitForSeconds(waitTime);

            SceneManager.LoadScene("Level0");            
            
        }

    


        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Application.Quit();  
        }




        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
               rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
            }
            
        }



        ChekMovementDirection();

        UpdateAnimation();
        AttackPunch();
        AttackKick();


        
        
    }

    private void FixedUpdate() 
    {   
        // ANT PC
        moveDirection = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        GroundCheck();

        
    }


    //----------------------- FUNKCIJOS ------------------------------


    private void GroundCheck()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
    }





    private void ChekMovementDirection()
    {
        if (isFacingRight && moveDirection < 0)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
        else if(!isFacingRight && moveDirection > 0)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        } 

        // Jeigu JUDAM ideta ANIMACIJA
        if (moveDirection > 0.1 || moveDirection < - 0.1)
        {
            isWalk = true; 
              
        }
        else
        {
            isWalk = false;
        }
    }

    private void UpdateAnimation()
    {
        anim.SetBool("isWalk", isWalk);
        anim.SetBool("isPunch", isPunch);
        anim.SetBool("isKick", isKick);
    }

    private void AttackPunch()
    {
        if (Input.GetKeyDown("p") && !isPunch)
        {

            soundAttack.Play();

            isPunch = true;

            StartCoroutine(DoAttackPunch());
        }
    
    }


    public void AttackPunchButton()
    {
       

       Debug.Log("Kertu !!!!!!!!!!!");
        
    
    }

    IEnumerator DoAttackPunch()
    {   
        attackHitBox.SetActive(true);
        yield return new WaitForSeconds(.5f);
        attackHitBox.SetActive(false);
        
        isPunch = false;
    }

    private void AttackKick()
    {
        if (Input.GetKeyDown("k") && !isKick)
        {
            soundAttack.Play();

            isKick = true;

            StartCoroutine(DoAttackKick());
        }
    
    }

    IEnumerator DoAttackKick()
    {   
        attackKickBox.SetActive(true);
        yield return new WaitForSeconds(.5f);
        attackKickBox.SetActive(false);

        isKick = false;
    }


    private void TakeDamage(int damage)
    {   
        //currentHealth = currentHealth - damage;
        currentHealth -= damage;

        anim.Play("player2Hit");

        healthBar.SetHealth(currentHealth);

        
        
    }


    // private void OnCollisionEnter2D(Collision2D collision) 
    // {
    //     if (collision.gameObject.CompareTag("enemyHitPunch"))
    //     {
    //         TakeDamage(20);
    //     }
        
    // }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        // if (collider.gameObject.name == "enemySight")
        // {
        //     print("MANE MATO :( !!!!");
        //     TakeDamage(20);
        // }

        if (collider.gameObject.tag == "enemyHitPunch")
        {
            soundHit.Play();

            Instantiate(bloodPlayer, transform.position, Quaternion.identity);

            TakeDamage(20);
            
        }


    }



}
