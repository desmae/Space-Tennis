using UnityEngine;
using UnityEngine.UI;

public class RoundsSlider : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] Slider roundsSlider;

    void Start()
    {
        roundsSlider.onValueChanged.AddListener((v) =>
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
    public void ChangeRounds()
    {

        Save();
    }
    private void Load()
    {
        roundsSlider.value = PlayerPrefs.GetFloat("");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("", gameManager.winningScore);
    }
}