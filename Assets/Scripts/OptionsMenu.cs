// OptionsMenu.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public void SetMusicVolume(float musicVolume)
    {
        Debug.Log(musicVolume);
    }

    public void SetRounds(float rounds)
    {
       Debug.Log (rounds);
    }

    public void SetPoints(float points)
    {
        Debug.Log(points);
    }
}
