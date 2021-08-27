using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    Animator animator;
    Object bulletRef;
    
    [SerializeField] 
    float xPos = 2f;

    [SerializeField] 
    float yPos = 1f;



    void Start()
    {
        bulletRef = Resources.Load("fire");
        animator = GetComponent<Animator>();
    }

  
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            animator.Play("player_shoot2");
            GameObject bullet = (GameObject)Instantiate(bulletRef);
            bullet.transform.position = new Vector3(transform.position.x + xPos, transform.position.y + yPos, -1);
        }
    }
}
