using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void Start()
    {
        //initialize store if first run or no store data
        if (!PlayerPrefs.HasKey("StoreState"))
        {
            PlayerPrefs.SetString("StoreState", JsonUtility.ToJson(new StoreState("Forest", 1, 1, 2)));
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelect");
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

    public void LoadFarm()
    {
        SceneManager.LoadScene("Farm");
    }

    public void LoadMarsh()
    {
        SceneManager.LoadScene("Marsh");
    }

    public void LoadForest()
    {
        SceneManager.LoadScene("Forest");
    }

    public void LoadCastle()
    {
        SceneManager.LoadScene("Castle");
    }

    public void LoadMountain()
    {
        SceneManager.LoadScene("Mountains");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
