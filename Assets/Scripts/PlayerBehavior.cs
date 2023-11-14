using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
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
        rb.velocity = new Vector2(rb.velocity.x, direction * moveSpeed);
    }

}
