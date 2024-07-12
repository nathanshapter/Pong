using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
   
    [SerializeField] float moveSpeed = 5;

    [SerializeField] float deviationDirection = 0;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
      
    }

    
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 moveDirection = (transform.right * moveSpeed) ;
        rb.velocity = moveDirection + new Vector2(0, deviationDirection);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moveSpeed = -moveSpeed;
            float differenceY = CalculateDifferenceInY(transform.position.y, collision.transform.position.y);
            print(differenceY);
        }
        else if (collision.gameObject.CompareTag("NorthBorder") || collision.gameObject.CompareTag("SouthBorder"))
        {
          
            Vector2 normal = collision.contacts[0].normal;

            
            rb.velocity = Vector2.Reflect(rb.velocity, normal);

            
            deviationDirection = -deviationDirection;
        }

        
       
    }
     

    float CalculateDifferenceInY(float ballY, float collisionY)
    {
        float difference = ballY - collisionY;
        deviationDirection = difference + Random.Range(-.15f,.15f);

       
        return difference;
    }

}
