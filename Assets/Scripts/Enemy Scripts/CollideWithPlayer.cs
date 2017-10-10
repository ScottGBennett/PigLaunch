using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithPlayer : MonoBehaviour
{
    GameObject spawnerObject;
    EnemySpawner spawnerScript;

    private void Start()
    {
        spawnerObject = GameObject.FindGameObjectWithTag("EnemySpawner");
        spawnerScript = spawnerObject.GetComponent<EnemySpawner>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Animator animator = gameObject.GetComponentInChildren<Animator>();
            EnemyWalk walkScript = GetComponent<EnemyWalk>();
			walkScript.isAlive = false;
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
