﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    GameObject enemyPrefab1, enemyPrefab2, enemy1Animation, enemy2Animation;
    [SerializeField]
    int numSpawns = 10;
    [SerializeField]
    float spawnDelay = .1f;
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

        shouldSpawn = true;
        StartCoroutine("Spawn");
    }
	
	
	void Update ()
    {

    }

    IEnumerator Spawn()
    {
       
        while (shouldSpawn && enemies.Count != 0)
        {
            GameObject enemySpawn = enemies.Dequeue();
            enemySpawn.transform.position = transform.position;
            enemySpawn.SetActive(true);
            yield return new WaitForSeconds(spawnDelay);
        }
        
        
    }
}
