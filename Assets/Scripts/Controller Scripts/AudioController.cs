using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    AudioSource buttonClickSound, pigOinkSound, enemy1Sound, enemy2Sound, backgroundMusic, groundBounce, coin;

    int shouldPlayFX, shouldPlayBG;

    // Use this for initialization
    void Start ()
    {
        //check if no pref data
        //set to default on = 1, if no previous data
        if (!PlayerPrefs.HasKey("ShouldPlayFX"))
        {
            PlayerPrefs.SetInt("ShouldPlayFX", 1);
        }

        if (!PlayerPrefs.HasKey("ShouldPlayBG"))
        {
            PlayerPrefs.SetInt("ShouldPlayBG", 1);
        }

        PlayBackgroundMusic();
    }

    public void PlayButtonSound()
    {
        if (PlayerPrefs.GetInt("ShouldPlayFX") == 1)
        {
            buttonClickSound.Play();
        }
    }
    
    public void PlayBackgroundMusic()
    {
        if (PlayerPrefs.GetInt("ShouldPlayBG") == 1)
        {
            backgroundMusic.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        backgroundMusic.Stop();
    }

    public void PlayPigSound()
    {
        if (PlayerPrefs.GetInt("ShouldPlayFX") == 1)
        {
            pigOinkSound.Play();
        }
    }

    public void PlayEnemy1Sound()
    {
        if (PlayerPrefs.GetInt("ShouldPlayFX") == 1)
        {
            enemy1Sound.Play();
        }
    }

    public void PlayEnemy2Sound()
    {
        if (PlayerPrefs.GetInt("ShouldPlayFX") == 1)
        {
            enemy2Sound.Play();
        }
    }

    public void PlayGroundBounceSound()
    {
        if (PlayerPrefs.GetInt("ShouldPlayFX") == 1)
        {
            groundBounce.Play();
        }
    }

    public void PlayCoinSound()
    {
        if (PlayerPrefs.GetInt("ShouldPlayFX") == 1)
        {
            coin.Play();
        }
    }
}
