using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollector : MonoBehaviour {

    [SerializeField]
    GameObject enemySpawnerObject;
    EnemySpawner enemySpawner;


    void Start ()
    {
        enemySpawner = enemySpawnerObject.GetComponent<EnemySpawner>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            //enemySpawner.AddEnemy(collision.gameObject);
            //collision.gameObject.SetActive(false);
			Destroy(collision.gameObject);
        }
    }
}
