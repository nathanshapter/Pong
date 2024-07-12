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
              

        moveSpeed = -moveSpeed;
        
        print(CalculateDifferenceInY(transform.position.y, collision.gameObject.transform.position.y));
        
    }
     

    float CalculateDifferenceInY(float ballY, float collisionY)
    {
        float difference = ballY - collisionY;
        deviationDirection = difference;
        return difference;
    }

}
