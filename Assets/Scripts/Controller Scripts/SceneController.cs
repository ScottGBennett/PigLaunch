using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Farm");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void ClearAllData()
    {
        PlayerPrefs.DeleteAll();
    }
}
