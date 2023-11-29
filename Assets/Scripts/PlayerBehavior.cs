using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float minY = -3.5f; // Adjust this based on your scene
    public float maxY = 3.5f;  // Adjust this based on your scene
    private Rigidbody2D rb;
    public bool player1; // is this player 1?
    float oldPlayerSpeed; // old player speed for dashing mechanic

    public bool slippery; // whether the paddle is slippery
    private float direction; // player direction
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
    private void FixedUpdate() 
    {
        Movement();
    }
    void Update()
    {
        Dash();


        if (isAI)
        {
            float targetYposition = GetNewYPosition();
            transform.position = new Vector3(transform.position.x, targetYposition, transform.position.z);
            maxY = 3.5f;
            minY = -3.5f;

            rb.velocity = new Vector2(rb.velocity.x, direction * aimoveSpeed);

        }
    }
  
    // Player movement
    void Dash()
    {
        if (player1)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                oldPlayerSpeed = moveSpeed;
                moveSpeed *= 1.4f;

            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                moveSpeed = oldPlayerSpeed;
            }
        }
        else
        {
            if (!isAI)
            {
                if (Input.GetKeyDown(KeyCode.RightShift))
                {
                    oldPlayerSpeed = moveSpeed;
                    moveSpeed *= 1.4f;

                }
                else if (Input.GetKeyUp(KeyCode.RightShift))
                {
                    moveSpeed = oldPlayerSpeed;
                }
            }
        }
    }
    void Movement()
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
        }
    }
}
