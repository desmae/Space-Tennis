using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CreditsButton : MonoBehaviour
{
    public GameObject button;
    public void OnButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
