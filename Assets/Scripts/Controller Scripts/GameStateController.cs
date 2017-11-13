using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameStateController : MonoBehaviour
{
    [HideInInspector]
    public bool gameOver;

    [SerializeField]
    GameObject summaryScreen;

    [SerializeField]
    HighScoreManager highScoreManager;



    public Text uiCoinsEarnedText, timeText, enemySquashText, sumScreenCoinsEarnedText;

    private int coinsEarned = 0, enemiesSquashed = 0;
    private float time;
    bool endRoundSceneDisplayed = false;
    // Use this for initialization
    void Start ()
    {
        summaryScreen.SetActive(false);
        gameOver = false;
        Time.timeScale = 1;
    }
    
    // Update is called once per frame
    void Update ()
    {
        
        if (gameOver && !endRoundSceneDisplayed)
        {
            Time.timeScale = 0;
            summaryScreen.SetActive(true);
            enemySquashText.text = "Enemies Squashed: " + enemiesSquashed;
            sumScreenCoinsEarnedText.text = "Coins Earned: " + coinsEarned;
            //check if current score beats highest score
            highScoreManager.CheckScore(enemiesSquashed, coinsEarned, time);
            //save number of coins earned to permanent score record
            if (PlayerPrefs.HasKey("Coins"))
            {
                int currentCoins = PlayerPrefs.GetInt("Coins");
                coinsEarned += currentCoins;
                PlayerPrefs.SetInt("Coins", coinsEarned);
            }
            else
            {
                PlayerPrefs.SetInt("Coins", coinsEarned);
            }

            endRoundSceneDisplayed = true;
        }

        timeUpdate();
    }

    //function to update the player's score
    public void incrementScore()
    {
        coinsEarned++;
        uiCoinsEarnedText.text = "Coins collected: " + coinsEarned;
    }

    //function to update the enemy squashed count
    public void incrementEnemyCount()
    {
        enemiesSquashed++;
    }

    private void timeUpdate()
    {
        time += Time.deltaTime;

        var minutes = Mathf.Floor(time / 59f);
        var seconds = time % 59f;
        var fraction = (time * 100f) % 100f;

        timeText.text = string.Format("Time Elapsed: {0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
    }
}
