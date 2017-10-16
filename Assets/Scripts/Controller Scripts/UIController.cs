using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Farm");
    }

    public void LoadHighscore()
    {
        SceneManager.LoadScene("HighScore");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadStore()
    {
        SceneManager.LoadScene("Store");
    }
}
