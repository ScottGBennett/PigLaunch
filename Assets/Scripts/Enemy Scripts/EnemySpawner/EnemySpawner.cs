using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    GameObject enemyPrefab1, enemyPrefab2, enemy1Animation, enemy2Animation;
    [SerializeField]
    int numSpawns = 10;

    [SerializeField]
    float spawnDelay = 2f;
    bool shouldSpawn;

    Queue<GameObject> enemies;

    public void AddEnemy(GameObject enemy)
    {
        enemies.Enqueue(enemy);
    }

    void Start ()
    {
		
        enemies = new Queue<GameObject>();
        for (int i = 0; i < numSpawns; i++)
        {
            GameObject temp = (GameObject)Instantiate(enemyPrefab1);
            temp.SetActive(false);
            enemies.Enqueue(temp);
            temp = null;
            temp = (GameObject)Instantiate(enemyPrefab2);
            temp.SetActive(false);
            enemies.Enqueue(temp);
        }

        shouldSpawn = false;
        
    }
    
    
    public void StartSpawn()
    {
        shouldSpawn = true;
        StartCoroutine("Spawn");

    }


    IEnumerator Spawn()
    {
       
        while (shouldSpawn && enemies.Count != 0)
        {
			/*
            GameObject enemySpawn = enemies.Dequeue();
            enemySpawn.transform.position = transform.position;
            enemySpawn.SetActive(true); */
			int randomNum = Random.Range (0, 2);
			GameObject enemySpawn;
			if (randomNum == 0) 
			{
				enemySpawn = Instantiate (enemyPrefab1);	
			} 
			else 
			{
				enemySpawn = Instantiate (enemyPrefab2);
			}
			enemySpawn.transform.position = transform.position;
            yield return new WaitForSeconds(Random.Range(0f, spawnDelay));
        }
        
        
    }
}
