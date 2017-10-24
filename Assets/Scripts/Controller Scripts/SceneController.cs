using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Farm");
    }

    public void LoadHighscore()
    {
        SceneManager.LoadScene("HighScoreMenu");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadStore()
    {
        SceneManager.LoadScene("ShopMenu");
    }

    public void ClearAllData()
    {
        PlayerPrefs.DeleteAll();
    }
}
