using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float minY = -3.5f; // Adjust this based on your scene
    public float maxY = 3.5f;  // Adjust this based on your scene
    private Rigidbody2D rb;
    public bool player1; // is this player 1?
    public float playerSpeed; 
    float oldPlayerSpeed; // old player speed for dashing mechanic

    public bool slippery; // whether the paddle is slippery
    private float direction; // player direction

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Dash();
    }
    private void FixedUpdate() 
    {
        Movement(playerSpeed);
    }
    // Player movement
    void Dash()
    {
        if (player1)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                oldPlayerSpeed = playerSpeed;
                playerSpeed *= 1.4f;

            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                playerSpeed = oldPlayerSpeed;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                oldPlayerSpeed = playerSpeed;
                playerSpeed *= 1.4f;

            }
            else if (Input.GetKeyUp(KeyCode.RightShift))
            {
                playerSpeed = oldPlayerSpeed;
            }
        }
        
    }
    void Movement(float moveSpeed)
    {
        if (player1)
        {
            if (slippery)
            {
                direction = Input.GetAxis("Vertical1");
            }
            else
            {
                direction = Input.GetAxisRaw("Vertical1");
            }
        }
        else
        {
            if (slippery)
            {
                direction = Input.GetAxis("Vertical2");
            }
            else
            {
                direction = Input.GetAxisRaw("Vertical2");
            }
        }
        float newYPosition = Mathf.Clamp(rb.position.y + direction * moveSpeed * Time.deltaTime, minY, maxY);
        rb.MovePosition(new Vector2(rb.position.x, newYPosition));
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
        }
    }
}
