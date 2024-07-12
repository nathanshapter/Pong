using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRacquet : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    Rigidbody2D rb;

    float minY = -4;
    float maxY = 4;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       

        InputMovement();
        ClampMovement();
    }

    private void ClampMovement()
    {
        Vector2 currentPosition = transform.position;
        float clampedY = Mathf.Clamp(currentPosition.y, minY, maxY);


        transform.position = new Vector2(currentPosition.x, clampedY);
    }

    private void InputMovement()
    {
        float moveInput = Input.GetAxis("Vertical");
        Vector2 moveDirection = transform.up * moveInput;

        rb.velocity = moveDirection * moveSpeed;
    }
}
