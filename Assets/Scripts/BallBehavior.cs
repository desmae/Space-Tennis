using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public Sprite[] sprites; // all the different sprites of the ball
    public Material[] materials; // all the different materials of the ball
    public static bool isSuper; // is the ball a super ball? Will it give two points?
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

        if (ballSpeed >= 10)
        {
            SuperBall();
        }
        else
        {
            RegularBall();
        }
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
    void RegularBall()
    {
        if (!isSuper) return;

        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        TrailRenderer trail = gameObject.GetComponent<TrailRenderer>();
        
        if (sprite.sprite != sprites[0])
        {
            sprite.sprite = sprites[0];
        }
        if (sprite.material != materials[0])
        {
            sprite.material = materials[0];
            trail.material = materials[0];

        }
        isSuper = false;
    }
    void SuperBall()
    {
        if (isSuper) return;

        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        TrailRenderer trail = gameObject.GetComponent<TrailRenderer>();

        if (sprite.sprite != sprites[1])
        {
            sprite.sprite = sprites[1]; 
        }
        if (sprite.material != materials[1])
        {
            sprite.material = materials[1];
            trail.material = materials[1];
        }
        isSuper = true;

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