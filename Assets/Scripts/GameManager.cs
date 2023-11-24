using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static GameManager;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    public GUISkin layout;

    public GameObject ball;
   
    public GameObject Paddle2;
    PlayerBehavior playerBehavior;
 


    void Awake()
    {
        playerBehavior = ball.GetComponent<PlayerBehavior>();
    }

    // Use this for initialization
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }
    void Update()
    {
        
    }
    public static void Score(string wallID)
    {
        if (wallID == "RightWall")
        {
            PlayerScore1++;
        }
        else
        {
            PlayerScore2++;
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

        if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "Player 1 Wins! ");
            ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if (PlayerScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "Player 2 Wins!");
            ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }


        if (GUI.Button(new Rect(Screen.width / 2 - 360, 20, 120, 30), "Switch Mode"))

        {
            {
            
                }


            }
        }
    }

     
           
        
