using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithPlayer : MonoBehaviour
{
    [SerializeField]
    AudioController audioController;
    GameObject spawnerObject;
    EnemySpawner spawnerScript;
    GameStateController gameStateController;

    private void Start()
    {
        gameStateController = GameObject.FindGameObjectWithTag("GameStateController").GetComponent<GameStateController>();
        spawnerObject = GameObject.FindGameObjectWithTag("EnemySpawner");
        spawnerScript = spawnerObject.GetComponent<EnemySpawner>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !gameStateController.gameOver)
        {
            Animator animator = gameObject.GetComponentInChildren<Animator>();
            EnemyWalk walkScript = GetComponent<EnemyWalk>();
            walkScript.isAlive = false;
            //gameObject.tag = "DeadEnemy";
            // 12 = deadEnemy Layer
            //gameObject.layer = 12;
            animator.Play("Die");
            StartCoroutine("FadeAfterDie");
        }
    }

    IEnumerator FadeAfterDie()
    {
        yield return new WaitForSeconds(1f);
        spawnerScript.AddEnemy(gameObject);
        gameObject.SetActive(false);
        
    }

}
