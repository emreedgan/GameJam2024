using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 5f; 
    private float jumpForce = 10f; 
    private float gravityScale = 3f; 
    private float descendForce = 10f; 

    private Rigidbody2D rb; 
    private bool isGrounded; 
    private bool isDescending;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        rb.gravityScale = gravityScale; 
    }

    void Update()
    {
        // Movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else if (Input.GetButton("Jump") && rb.velocity.y > 0) // Holding jump button
        {
            rb.gravityScale = gravityScale / 2;
        }
        else // Release jump button
        {
            rb.gravityScale = gravityScale;
        }

        // Descending
        if (Input.GetKey(KeyCode.S))
        {
            isDescending = true;
            rb.velocity = new Vector2(rb.velocity.x, -descendForce);
        }
        else if (isDescending)
        {
            isDescending = false;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if player is grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if player leaves the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
