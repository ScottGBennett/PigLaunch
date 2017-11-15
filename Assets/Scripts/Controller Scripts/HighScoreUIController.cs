using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreUIController : MonoBehaviour
{

    [SerializeField]
    Text enemiesText, coinText, secondsText, sceneLabelText;

    Levels currentLevel;


    void Start ()
    {
        currentLevel = Levels.Farm;
        UpdateUI();
    }
    

    void UpdateUI()
    {
        Score scoreObject;
        if (PlayerPrefs.HasKey(currentLevel.ToString()))
        {
            string scoreString = PlayerPrefs.GetString(currentLevel.ToString());
            scoreObject = JsonUtility.FromJson<Score>(scoreString);
        }
        else
        {
            scoreObject = new Score(0, 0, 0f);
        }

        sceneLabelText.text = currentLevel.ToString();
        enemiesText.text = scoreObject.numEnemiesSquashed.ToString();
        coinText.text = scoreObject.numCoinsCollected.ToString();
        secondsText.text = scoreObject.numSecondsSurvived.ToString();
    }

    public void MoveUIForward()
    {
        if (currentLevel < Levels.Mountains)
        {
            currentLevel++;
            UpdateUI();
        }
    }

    public void MoveUIBackward()
    {
        if (currentLevel > Levels.Farm)
        {
            currentLevel--;
            UpdateUI();
        }
    }

    public void GoHome()
    {
        SceneManager.LoadScene("MainMenu");
    }

    enum Levels
    {
        Farm,
        Forest,
        Marsh,
        Castle,
        Mountains
    }
}

