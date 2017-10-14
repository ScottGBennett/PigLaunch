using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    [HideInInspector]
    public bool gameOver;

    [SerializeField]
    GameObject summaryScreen;

	// Use this for initialization
	void Start ()
    {
        summaryScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            summaryScreen.SetActive(true);
        }
	}
}
