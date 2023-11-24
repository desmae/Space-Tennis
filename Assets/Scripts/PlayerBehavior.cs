using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float minY = -3.5f; // Adjust this based on your scene
    public float maxY = 3.5f;  // Adjust this based on your scene
    private Rigidbody2D rb;
    public bool player1; // is this player 1?
    private float direction;
    public Vector3 startPosition;
    private Vector2 forwardDirection;
    public float moveSpeed;
    public float aimoveSpeed;

    public bool isAI;
    void Start()

    {
       
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallBehavior>(); 
        if (isAI)
        {
            forwardDirection = Vector2.left;
        }
        startPosition = transform.position;
    }

    void Update()
    {
        Movement();


        if (isAI)
        {
            float targetYposition = GetNewYPosition();
            transform.position = new Vector3(transform.position.x, targetYposition, transform.position.z);
            maxY = 3.5f;
            minY = -3.5f;


        }
        rb.velocity = new Vector2(rb.velocity.x, direction * aimoveSpeed);
    }
    // Player movement

 

    void Movement()
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
       
    private BallBehavior ball;

    private float GetNewYPosition()
    {
        float result = transform.position.y;

        if (isAI)
        {
            if (ball)
                result = Mathf.MoveTowards(transform.position.y, ball.transform.position.y, aimoveSpeed * Time.deltaTime);

        }
        else
        {
            result = transform.position.y + direction;
        }
        return result;
    }
  
        

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Paddle Touched Wall");
        }
    }
}