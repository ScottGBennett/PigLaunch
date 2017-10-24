using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour {

    [SerializeField]
    string currentSceneName;

    Score score;
    
    // Use this for initialization
    void Start ()
    {
        if (PlayerPrefs.HasKey(currentSceneName))
        {
            //get current highscore as JSON string and convert 
            string scoreStr = PlayerPrefs.GetString(currentSceneName);
            score = JsonUtility.FromJson<Score>(scoreStr);
        }
        else
        {
            score = new Score(0, 0, 0f);
            
        }
    }


    public void CheckScore(int enemies, int coins, float seconds)
    {

        if (enemies > score.numEnemiesSquashed)
        {
            score.numEnemiesSquashed = enemies;
        }
        if (coins > score.numCoinsCollected)
        {
            score.numCoinsCollected = coins;
        }
        if (seconds > score.numSecondsSurvived)
        {
            score.numSecondsSurvived = seconds;
        }

        //save high score to PlayerPrefs as a JSON string
        string scoreString = JsonUtility.ToJson(score);
        PlayerPrefs.SetString(currentSceneName, scoreString);
    }


}


class Score
{
    //these must be public to serialize using Unity.JSONUtility
    public int numEnemiesSquashed;
    public int numCoinsCollected;
    public float numSecondsSurvived;

    public Score(int enemies, int coins, float seconds)
    {
        numEnemiesSquashed = enemies;
        numCoinsCollected = coins;
        numSecondsSurvived = seconds;
    }
}
