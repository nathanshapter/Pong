using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ComputerRacquet : MonoBehaviour
{
    float minY = -4;
    float maxY = 4;
    [SerializeField] float xPosition = 8f;
    Rigidbody2D rb;
    [SerializeField] Ball ball;
    [SerializeField] float moveSpeed= 10f;

    Vector2 randomOffset;

    float positionOffsetvalue = .2f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = FindObjectOfType<Ball>();
        
    }

   
    void Update()
    {
        FollowBall();
        ClampMovement();
    }
    private void ClampMovement()
    {
        Vector2 currentPosition = transform.position;
        float clampedY = Mathf.Clamp(currentPosition.y, minY, maxY);


        transform.position = new Vector2(xPosition, clampedY);
    }

    void FollowBall()
    {
        Vector2 moveDirection = (ball.transform.position - transform.position).normalized;
         

        moveDirection += randomOffset;

        moveDirection.Normalize();

        rb.velocity = moveDirection *moveSpeed ;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            randomOffset = new Vector2(Random.Range(-positionOffsetvalue, positionOffsetvalue), Random.Range(-positionOffsetvalue, positionOffsetvalue));
        }
    }
}
