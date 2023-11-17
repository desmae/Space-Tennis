using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float minY = -3.5f; // Adjust this based on your scene
    public float maxY = 3.5f;  // Adjust this based on your scene
    private Rigidbody2D rb;
    public bool player1; // is this player 1?
    public float playerSpeed; // player direction
    private float direction; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement(playerSpeed);
        
    }
    // Player movement
    void Movement(float moveSpeed)
    {
        if (player1)
        {
            direction = Input.GetAxisRaw("Vertical1");
        }
        else
        {
            // I implemented the "Horizontal" axis into Vertical2 to save on coding space, using Vertical2 for player 2.
            direction = Input.GetAxisRaw("Vertical2");
        }
        float newYPosition = Mathf.Clamp(rb.position.y + direction * moveSpeed * Time.deltaTime, minY, maxY);
        rb.MovePosition(new Vector2(rb.position.x, newYPosition));
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Paddle Touched Wall");
        }
    }
}
