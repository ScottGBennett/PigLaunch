﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour 
{
    [SerializeField]
    Rigidbody2D playerRigidBody;

    [SerializeField]
    int maxBounces = 2;

    
    float groundBounceForce = .5f, enemyBounceForce = 10f;

    [SerializeField]
    AudioController audioController;

    int currentBounces = 0;

    StoreState storeState;

    GameStateController gameStateController;

	[SerializeField]
	PlayerController playerController;

    EnemyWalk enemyWalk;

    private void Start()
    {
        gameStateController = GameObject.FindGameObjectWithTag("GameStateController").GetComponent<GameStateController>();

        //get current state from player prefs
        string storeStateString = PlayerPrefs.GetString("StoreState");
        storeState = JsonUtility.FromJson<StoreState>(storeStateString);

        //get values for ground bounce force, enemy bounce force, and number of attacks
        groundBounceForce *= storeState.groundForceLevel;
        enemyBounceForce *= storeState.enemyForceLevel;
        enemyWalk = GetComponent<EnemyWalk>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Background"))
        {
            Vector2 bounceVector = Vector2.up + Vector2.right;
            playerRigidBody.AddForce  (bounceVector * groundBounceForce, ForceMode2D.Impulse);
            currentBounces++;
            audioController.PlayGroundBounceSound();
            Debug.Log("Grounded!");
            gameStateController.onGround = true;
        }
        else if (collision.gameObject.CompareTag("enemy"))
        {
            Vector2 bounceVector = Vector2.up + Vector2.right;
            playerRigidBody.AddForce (bounceVector * enemyBounceForce, ForceMode2D.Impulse);
            currentBounces = 0;
            //gameStateController.incrementEnemyCount();
            //audioController.PlayEnemy1Sound();
			playerController.HitEnemy ();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Background"))
        {
            gameStateController.onGround = false;
            Debug.Log("Ungrounded");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            gameStateController.incrementScore();
            audioController.PlayCoinSound();
        }
    }

}
