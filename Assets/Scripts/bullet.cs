using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody2D rigi2D;

    //public Vector2 StartingVelocity; 

    [SerializeField] 
    float destroyTime;
    
    void Start()
    {
        rigi2D = GetComponent<Rigidbody2D>();
        Invoke("DestroySelf", destroyTime);
    }

    
    void Update()
    {
        rigi2D.velocity = new Vector2(3, 0);
        //rigi2D.velocity = StartingVelocity;
        // rigi2D.AddForce(new Vector2(25, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
