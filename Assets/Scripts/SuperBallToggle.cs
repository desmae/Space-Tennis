using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SuperBallToggle : MonoBehaviour
{
    public Toggle superBallToggle;

  


    void Start()
    {
        // Add a listener to the toggle component to detect changes
        superBallToggle.onValueChanged.AddListener(OnValueChanged);

        // Set the initial name for the toggle button

    }

    public void OnValueChanged(bool isON)
    {
      
        BallBehavior.isSuper = isON;

        // Update the game logic based on the selected mode
        UpdateSuperBall();

        // Update the name of the toggle button

    }

    public void UpdateSuperBall()
    {
        if (BallBehavior.isSuper)
        {
            
            Debug.Log("Switched to SuperBall");
        }
        else
        {
        
            Debug.Log("Switched to 2 RegularBall");
        }
    }

}

