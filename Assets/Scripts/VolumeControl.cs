using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
   
    void Start()
    {
        volumeSlider.onValueChanged.AddListener((v) =>
        {
            
        });
        if (!PlayerPrefs.HasKey(""))
        {
            PlayerPrefs.SetFloat("", 1);
            Load();
        }
        else
        {
            Load();
        }
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("", volumeSlider.value);
    }
}

