using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerModeToggle : MonoBehaviour
{
    public Toggle playerToggle;

    // Static variable to store the player mode information
  

    void Start()
    {
        // Add a listener to the toggle component to detect changes
        playerToggle.onValueChanged.AddListener(OnValueChanged);

        // Set the initial name for the toggle button
    
    }

    public void OnValueChanged(bool isOn)
    {
        // Toggle between 1 player and 2 player modes
        PlayerBehavior.isAI = isOn;
   
        // Update the game logic based on the selected mode
        UpdatePlayerMode();
   
        // Update the name of the toggle button

    }

    void UpdatePlayerMode()
    {
        if (PlayerBehavior.isAI)
        {
            // Implement logic for 2 player mode
            Debug.Log("Switched to 1 Player Mode");
        }
        else
        {
            // Implement logic for 1 player mode
            Debug.Log("Switched to 2 Player Mode");
        }
    }

}

