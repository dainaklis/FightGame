using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manekenas : MonoBehaviour
{
    
    [SerializeField]  private int maxHealth = 1000;

    [SerializeField]  private int currentHealth;

    [SerializeField]  private  healthBarEnemy healthBarEnemy;


    //SHAKING
    [SerializeField] private float shakeAmount; 
    private Vector2 startPos;
    private bool isShaking = false;





    void Start()
    {
        currentHealth = maxHealth;
        healthBarEnemy.SetMaxHealthEnemy(maxHealth);

        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (isShaking)
        {
            transform.position = startPos + UnityEngine.Random.insideUnitCircle * shakeAmount;  
        }

        if (currentHealth <= 0)
        {   
            Destroy(gameObject);
        }

    }


    // ----------------------------------------------------------------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.name == "AttackHitBox" )
        {
            TakeDamage(20);

            StartCoroutine(DoShaking());
        }

        else if (collider.gameObject.name == "AttackKickBox" )
        {
            TakeDamageKick(100);

            StartCoroutine(DoShaking());
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
        
    }
}
