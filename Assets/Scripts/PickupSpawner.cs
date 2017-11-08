using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject coinPrefab;
    [SerializeField]
    int numSpawns = 10;
    [SerializeField]
    float spawnDelay = .1f;
    bool shouldSpawn;

    Queue<GameObject> coins;

    public void AddEnemy(GameObject coin)
    {
        coins.Enqueue(coin);
    }

    void Start()
    {
        coins = new Queue<GameObject>();
        for (int i = 0; i < numSpawns; i++)
        {
            GameObject temp = (GameObject)Instantiate(coinPrefab);
            temp.SetActive(false);
            coins.Enqueue(temp);
        }

        shouldSpawn = true;
        StartCoroutine("Spawn");
    }


    void Update()
    {

    }

    IEnumerator Spawn()
    {

        while (shouldSpawn && coins.Count != 0)
        {

            //get coin from queue named coins
            GameObject coinSpawn = coins.Dequeue();

            //spawn at location between 1.5 and -2.2 on y axis
            //get random value between these numbers
            float randomYValue = Random.Range(-2.2f, 1.5f);
            //set position of new coin spawn to the position (X, Y) = (spawner position, random value)
            coinSpawn.transform.position = new Vector3(transform.position.x, randomYValue);
            coinSpawn.SetActive(true);
            yield return new WaitForSeconds(spawnDelay);
        }


    }
}
