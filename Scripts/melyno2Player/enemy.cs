using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{   

  

    [SerializeField]  private int maxHealth = 100;
    [SerializeField]  private int currentHealth;
    [SerializeField]  private  healthBarEnemy healthBarEnemy;


    [SerializeField] GameObject enemyHitPunch;
    [SerializeField] GameObject enemySight;



    private bool enemyPunch;
    private bool enemyWalk;


    private bool isShaking = false;
    private Vector2 startPos;
    [SerializeField] private float shakeAmount;
    
    
    [SerializeField] Transform player;
    [SerializeField] private float agroRange;
    [SerializeField] private float moveSpeed;
    private float distToPlayer;

    private Rigidbody2D rg2D;
    private Animator enemyAnim;

    //You Win Bar
    [SerializeField] private GameObject winText;
    [SerializeField] private float waitTime;

    //Next LEVEL
    [SerializeField] private string nextLevel; 


    //Sound
    [SerializeField] private AudioSource soundEnemyAttack, soundEnemyHit, soundEnemyDead;

    [SerializeField] private GameObject bloodHit;

    
    
    // Start is called before the first frame update
    void Start()
    {

        rg2D = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();

        currentHealth = maxHealth;
        healthBarEnemy.SetMaxHealthEnemy(maxHealth);

        startPos = transform.position;

        enemyHitPunch.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        UpdateAnimation();

        EnemyPunch();

        distToPlayer = Vector2.Distance(transform.position, player.position);
        
        if (distToPlayer < agroRange)
        {
            //ChasePlayer();
        
        }
        else
        {
            //StopChasingPlayer();
        }


        if (isShaking)
        {
            transform.position = startPos + UnityEngine.Random.insideUnitCircle * shakeAmount;  
        }

        if (currentHealth <= 0)
        {   
            //GetComponent<Collider2D>().enabled = false;
            
            //ATJUNGIA SCRIPTS
            //this.enabled = false;
            

            StartCoroutine(WinAndLoad());
        }

        IEnumerator WinAndLoad()
        {   
            enemyAnim.Play("enemyDead");
            
            yield return new WaitForSeconds(waitTime);

            Destroy(gameObject, 3f);

            winText.SetActive(true);

            yield return new WaitForSeconds(waitTime);

            SceneManager.LoadScene(nextLevel);            
            
        }


      
    }

    //--------------------METODAI--------------------------------------------------------------------


    private void ChasePlayer()
    {
       if (transform.position.x < player.position.x)
       {
           rg2D.velocity = new Vector2(moveSpeed, 0);
           transform.localScale = new Vector2(1, 1);
       } 
       else
       {
           rg2D.velocity = new Vector2(-moveSpeed, 0);
           transform.localScale = new Vector2(-1, 1);
       }

       enemyWalk = true;
    }

    private void StopChasingPlayer()
    {
        rg2D.velocity =  new Vector2(0, 0);

        enemyWalk = false;
    }


    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.name == "AttackHitBox" )
        {
            //soundEnemyHit.Play();
            soundManager.PlaySound("hit");

            Instantiate(bloodHit, transform.position, Quaternion.identity);

            TakeDamage(20);

            StartCoroutine(DoShaking());
        }

        else if (collider.gameObject.name == "AttackKickBox" )
        {
            //soundEnemyHit.Play();
            soundManager.PlaySound("hit");

            Instantiate(bloodHit, transform.position, Quaternion.identity);
            
            TakeDamageKick(30);

            StartCoroutine(DoShaking());
        }

        else if (collider.gameObject.tag == "Player")
        {   
           //EnemyPunchAuto();            
        }
    }

 




    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
    
        healthBarEnemy.SetHealthEnemy(currentHealth);

    }

    private void TakeDamageKick(int damage)
    {
        currentHealth -= damage;
    
        healthBarEnemy.SetHealthEnemy(currentHealth);
    }

    IEnumerator DoShaking()
    {   
        isShaking = true;
        yield return new WaitForSeconds(.3f);
        isShaking = false;
        transform.position = new Vector2(transform.position.x, -0.742865f);
        
        
    }


    private void EnemyPunch()
    {
        if (Input.GetKeyDown("l") && !enemyPunch)
        {
            //soundEnemyAttack.Play();
            soundManager.PlaySound("attack");

            enemyPunch = true;

            StartCoroutine(DoAttackEnemyPunch());
        }
    
    }

    private void EnemyPunchAuto()
    {
        if (true && !enemyPunch)
        {
            enemyPunch = true;

            StartCoroutine(DoAttackEnemyPunch());
        }
    }

    IEnumerator DoAttackEnemyPunch()
    {   
        enemyHitPunch.SetActive(true);
        yield return new WaitForSeconds(.5f);
        enemyHitPunch.SetActive(false);
        
        enemyPunch = false;
    }


    private void UpdateAnimation()
    {
        enemyAnim.SetBool("enemyPunch", enemyPunch);
        enemyAnim.SetBool("enemyWalk", enemyWalk);
        
        
    }




}
