using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    float randomAngle; // random angle that the ball chooses when it hits a paddle (code only)
    private Rigidbody2D rb;
    public float ballSpeed; // speed of the ball (change in inspector)
    public Vector2 direction; // direction of the ball (code only, visible in inspector and affectable by external scripts just in case)
    void Start()
    {
        randomAngle = Random.Range(-15f, 15f);
        rb = GetComponent<Rigidbody2D>();
        GameBegin();
        direction = new Vector2(Random.Range(0, 2) == 0 ? -1 : 1,
        Mathf.Tan(randomAngle * Mathf.Deg2Rad));
    }

    void Update()
    {
        rb.velocity = rb.velocity.normalized * ballSpeed;
    }

    // flips a theoretical coin to see which direction the ball travels in
    void GameBegin()
    {
        float selection = Random.Range(1, 3); // three is not included according to my tests
        Debug.Log($"{selection} was chosen as a direction.");
        if (selection == 1)
        {
            Debug.Log("Ball going left");
            rb.velocity = Vector2.left * ballSpeed;
        }
        else
        {
            Debug.Log("Ball going right");
            rb.velocity = Vector2.right * ballSpeed;
        }
    }
    void ResetBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = Vector2.zero;
        ballSpeed = 4;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GameBegin", 1);
    }
    void Dash()
    {
        // to be implemented during alpha phase in the case that we would like to be able to let players double their paddle's speed to be able to catch the ball in later stages (shift key)
        // consider the ball score two points instead of one if it is fast enough (regular ball speed is 4, if it's 10, do double points). 
        // ^^^^^^ Higher stakes, faster gameplay, more of a reward if you win.
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
        {
            randomAngle = Random.Range(-15f, 15f);
            Debug.Log($"Touched paddle:{other.gameObject.name}");
            direction = new Vector2(Random.Range(0, 2) == 0 ? -1 : 1,
            Mathf.Tan(randomAngle * Mathf.Deg2Rad)).normalized;
            ballSpeed = ballSpeed * 1.05f;
            rb.velocity = direction * ballSpeed;

        }
        else
        {
            Debug.Log($"Touched something else:{other.gameObject.name}");

        }
    }
}