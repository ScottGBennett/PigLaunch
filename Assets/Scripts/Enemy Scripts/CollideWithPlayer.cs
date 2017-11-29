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
    EnemyWalk enemyWalk;
    private void Start()
    {
        gameStateController = GameObject.FindGameObjectWithTag("GameStateController").GetComponent<GameStateController>();
        spawnerObject = GameObject.FindGameObjectWithTag("EnemySpawner");
        spawnerScript = spawnerObject.GetComponent<EnemySpawner>();
        enemyWalk = GetComponent<EnemyWalk>();
        GameObject audioObject = GameObject.FindGameObjectWithTag("AudioController");
        audioController = audioObject.GetComponent<AudioController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !gameStateController.gameOver)
        {
 
            if (enemyWalk.isAlive)
            {
                Animator animator = gameObject.GetComponentInChildren<Animator>();
                animator.Play("Die");
                StartCoroutine("FadeAfterDie");
                gameStateController.incrementEnemyCount();
                audioController.PlayEnemy1Sound();
            }
            enemyWalk.isAlive = false;
        }
    }

    IEnumerator FadeAfterDie()
    {
        yield return new WaitForSeconds(1f);
        //spawnerScript.AddEnemy(gameObject);
        //gameObject.SetActive(false);
        Destroy(gameObject);
        
    }

}
