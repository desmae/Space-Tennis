using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    float randomAngle;
    private Rigidbody2D rb;
    public float ballSpeed;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        randomAngle = Random.Range(-15f, 15f);
        rb = GetComponent<Rigidbody2D>();
        GameBegin();
        direction = new Vector2(Random.Range(0, 2) == 0 ? -1 : 1,
        Mathf.Tan(randomAngle * Mathf.Deg2Rad));
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = rb.velocity.normalized * ballSpeed;
    }

    // flips a theoretical coin to see which direction the ball travels in
    void GameBegin()
    {
        float selection = Random.Range(1,2);

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

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2")) 
        {
            Debug.Log($"Touched paddle:{other.gameObject.name}");
            direction = new Vector2(Random.Range(0, 2) == 0 ? -1 : 1,
            Mathf.Tan(randomAngle * Mathf.Deg2Rad));
            rb.velocity = direction.normalized * ballSpeed;
        }
        else
        {
            Debug.Log($"Touched something else:{other.gameObject.name}");

            rb.velocity = Vector2.Reflect(rb.velocity, other.contacts[0].normal);
        }
    }
}
