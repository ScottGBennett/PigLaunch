using UnityEngine;
using UnityEngine.UI;

public class OptionsUIController : MonoBehaviour
{
    [SerializeField]
    Text bgMusicButton, soundFXButton;

    // Use this for initialization
    void Start ()
    {
        updateUI();
    }
    
    public void ToggleFX()
    {
        if (PlayerPrefs.GetInt("ShouldPlayFX") == 1)
        {
            PlayerPrefs.SetInt("ShouldPlayFX", 0);
        }
        else
        {
            PlayerPrefs.SetInt("ShouldPlayFX", 1);
        }

        updateUI();
    }

    public void ToggleBG()
    {
        if (PlayerPrefs.GetInt("ShouldPlayBG") == 1)
        {
            PlayerPrefs.SetInt("ShouldPlayBG", 0);
        }
        else
        {
            PlayerPrefs.SetInt("ShouldPlayBG", 1);
        }

        updateUI();
    }

    void updateUI()
    {
        if (PlayerPrefs.HasKey("ShouldPlayFX"))
        {
            if (PlayerPrefs.GetInt("ShouldPlayFX") == 1)
            {
                //current playing FX, so button text should indicate a press = off
                soundFXButton.text = "Turn FX Off";
            }
            else
            {
               soundFXButton.text = "Turn FX On";
            }
        }

        if (PlayerPrefs.HasKey("ShouldPlayBG"))
        {
            if (PlayerPrefs.GetInt("ShouldPlayBG") == 1)
            {
                bgMusicButton.text = "Turn Music Off";
            }
            else
            {
                bgMusicButton.text = "Turn Music On";
            }
        }
    }
}
