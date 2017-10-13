using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    [HideInInspector]
    public bool gameOver;

    [SerializeField]
    GameObject gameOverText;

	// Use this for initialization
	void Start ()
    {
        gameOverText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverText.SetActive(true);
        }
	}
}
