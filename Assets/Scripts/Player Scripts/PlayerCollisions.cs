using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour 
{
    [SerializeField]
    Rigidbody2D playerRigidBody;

    [SerializeField]
    int maxBounces = 2;

    [SerializeField]
    float groundBounceForce = 1f, enemyBounceForce = 1f;

    int currentBounces = 0;

    GameStateController gameStateController;

    private void Start()
    {
        gameStateController = GameObject.FindGameObjectWithTag("GameStateController").GetComponent<GameStateController>();
    }

        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            if (currentBounces >= maxBounces)
            {
                playerRigidBody.velocity = Vector2.zero;
            }

            Vector2 bounceVector = Vector2.up + Vector2.right;
            playerRigidBody.AddForce  (bounceVector * groundBounceForce, ForceMode2D.Impulse);
            currentBounces++;
        }
        else if (collision.gameObject.CompareTag("enemy"))
        {
            Vector2 bounceVector = Vector2.up + Vector2.right;
            playerRigidBody.AddForce (bounceVector * enemyBounceForce, ForceMode2D.Impulse);
            currentBounces = 0;
			gameStateController.incrementEnemyCount ();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            gameStateController.incrementScore();
        }
    }


}
