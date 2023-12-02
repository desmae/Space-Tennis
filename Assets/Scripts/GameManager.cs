using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    // Text
    public static Animator statusTextAnimator;
    public static TextMeshProUGUI statusText;
    public GUISkin layout;

    public GameObject ball;

    public GameObject Paddle2;
    PlayerBehavior playerBehavior;
    static BallBehavior ballBehavior;

    // Define the winning score as a variable
    public int winningScore = 0;

    void Awake()
    {
        playerBehavior = ball.GetComponent<PlayerBehavior>();
        ballBehavior = ball.GetComponent<BallBehavior>();
        statusTextAnimator = ball.GetComponent<BallBehavior>().statusTextAnimator;
        statusText = ball.GetComponent<BallBehavior>().statusText;
    }

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    void Update()
    {
        // Your update logic here
    }

    public static void Score(string wallID)
    {
        if (wallID == "RightWall")
        {
            if (BallBehavior.isSuper)
            {
                PlayerScore1 += 2;
            }
            else
            {
                PlayerScore1++;
            }
            statusText.text = $"Player 1 Scored!";
            statusTextAnimator.SetTrigger("PlayText");
        }
        else
        {
            if (BallBehavior.isSuper)
            {
                PlayerScore2 += 2;
            }
            else
            {
                PlayerScore2++;
            }
            statusText.text = $"Player 2 Scored!";
            statusTextAnimator.SetTrigger("PlayText");
        }
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 200 - 12, 20, 100, 100), "Player One :" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 120 + 12, 20, 100, 100), "Player Two :" + PlayerScore2);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 20, 120, 30), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            ball.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        // Use the winningScore variable here
        if (PlayerScore1 == winningScore)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "Player 1 Wins! ");
            ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if (PlayerScore2 == winningScore)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "Player 2 Wins!");
            ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }
}


