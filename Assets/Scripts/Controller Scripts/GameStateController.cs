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
        if (gameOver)
        {
            Time.timeScale = 0;
            summaryScreen.SetActive(true);
            enemySquashText.text = "Enemies Squashed: " + enemiesSquashed;
            sumScreenCoinsEarnedText.text = "Coins Earned: " + coinsEarned;
            highScoreManager.CheckScore(enemiesSquashed, coinsEarned, time);
            
        }

        timeUpdate();
    }

    //function to update the player's score
    public void incrementScore()
    {
        coinsEarned++;
        uiCoinsEarnedText.text = "Pickups collected: " + coinsEarned;
    }

    //function to update the enemy squashed count
    public void incrementEnemyCount()
    {
        enemiesSquashed++;
    }

    private void timeUpdate()
    {
        time += Time.deltaTime;

        var minutes = time / 60;
        var seconds = time % 60;
        var fraction = (time * 100) % 100;

        timeText.text = string.Format("Time Elapsed: {0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
    }
}
