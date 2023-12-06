using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PowerUpBehavior : MonoBehaviour
{
    public enum PowerUpType {BallSizeUp, SlipperyPaddle, PaddleSpeedUp, BallSizeDown, 
    PaddleSizeDown, CrazyBall, CenterPaddle, PaddleSizeUp};
    public PowerUpType powerUpType;

    // Text stuff
    public Animator statusTextAnimator;
    public TextMeshProUGUI statusText;

    // other objects

    public GameObject ball;
    public GameObject paddle1;
    public GameObject paddle2;

    public Animator powerUpAnimator;
    public PowerUpSpawnerBehavior powerUpSpawnerBehavior;

    public PlayerBehavior paddleBehavior1;
    public PlayerBehavior paddleBehavior2;
    
    public PhysicsMaterial2D physicsMaterial2D;

    // Ball Size Up: Ball becomes bigger
    // Slippery Paddle: Paddles both become slippery and move like they're on ice
    // Paddle Speed Up: Both paddles become faster
    // Ball Size Down: Ball becomes smaller
    // Paddle Size Down: Paddles both become smaller
    // Crazy Ball: Ball moves in a wider angle when bouncing off of paddles
    // Center Paddle: Paddles are moved closer to the center making the game temporarily more difficult
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ChooseRandom();
        
    }
    void ChooseRandom()
    {
        int randNum = Random.Range(0, 7);
        
        if (randNum == 0)
        {
            powerUpType = PowerUpType.BallSizeUp;
        }
        else if (randNum == 1)
        {
            powerUpType = PowerUpType.SlipperyPaddle;
        }
        else if (randNum == 2)
        {
            powerUpType = PowerUpType.PaddleSpeedUp;
        }
        else if (randNum == 3)
        {
            powerUpType = PowerUpType.BallSizeDown;
        }
        else if (randNum == 4)
        {
            powerUpType = PowerUpType.PaddleSizeDown;
        }
        else if (randNum == 5)
        {
            powerUpType = PowerUpType.CenterPaddle;
        }
        else if (randNum == 6)
        {
            powerUpType = PowerUpType.CrazyBall;
        }

    }
    void PowerUp()
    {
        if (powerUpType == PowerUpType.BallSizeUp)
        {
            ball.transform.localScale += new Vector3 (0.1f, 0.1f);
        }
        else if (powerUpType == PowerUpType.SlipperyPaddle)
        {
            paddleBehavior1.slippery = true;
            paddleBehavior2.slippery = true;
        }
        else if (powerUpType == PowerUpType.PaddleSpeedUp)
        {
            paddleBehavior1.moveSpeed += 3;
            paddleBehavior2.moveSpeed += 3;
        }
        else if (powerUpType == PowerUpType.BallSizeDown)
        {
            ball.transform.localScale -= new Vector3 (0.1f, 0.1f);
        }
        else if (powerUpType == PowerUpType.PaddleSizeDown)
        {
            paddle1.transform.localScale += new Vector3 (0, -0.05f);
            paddle2.transform.localScale += new Vector3 (0, -0.05f);
        }
        else if (powerUpType == PowerUpType.CrazyBall)
        {
            ball.GetComponent<BallBehavior>().randomAngleRange = 45f;
        }
        else if (powerUpType == PowerUpType.CenterPaddle)
        {
            paddle1.transform.position += new Vector3 (2, 0);
            paddle2.transform.position += new Vector3 (-2, 0);
        }
    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(20);

        ball.transform.localScale = new Vector2 (0.25f, 0.25f);

        paddleBehavior1.slippery = false;
        paddleBehavior2.slippery = false;

        paddleBehavior1.moveSpeed = 6;
        paddleBehavior2.moveSpeed = 6;

        paddle1.transform.localScale = new Vector3 (0.1f, 0.2f);
        paddle2.transform.localScale = new Vector3 (0.1f, 0.2f);

        paddle1.transform.position = new Vector3 (-8.5f, paddle1.transform.position.y);
        paddle2.transform.position = new Vector3 (8.5f, paddle2.transform.position.y);
        ball.GetComponent<BallBehavior>().randomAngleRange = 15f;

        Debug.Log("reset");
        statusText.text = $"Power Up Expired!";
        statusTextAnimator.SetTrigger("PlayText");

        yield return new WaitForSeconds(1);
        Destroy(gameObject); // deletes the game object here for performance
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!other.gameObject.CompareTag("Ball")) return;
        PowerUp();
        Debug.Log($"powerup chosen {powerUpType}");
        statusText.text = $"{powerUpType}!";
        statusTextAnimator.SetTrigger("PlayText");
        StartCoroutine(Reset());
        StartCoroutine(GarbageCollection());
    }
    IEnumerator GarbageCollection()
    {
        powerUpAnimator.SetBool("PowerUpCollected", true);
        yield return new WaitForSeconds(0.67f);
        gameObject.transform.position = new Vector2 (10000, 10000); // garbage collection location

    }
}
