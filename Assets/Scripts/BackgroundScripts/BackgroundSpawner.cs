using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject backgroundToSpawn;

    [SerializeField]
    int numBackgroundsToSpawn;

    [SerializeField]
    int backgroundQueueBuffer;

    [SerializeField]
    Transform lastSpawnedBackground;

    Queue<GameObject> backgroundQueue;

    int numBackgroundsSpawned;

    void Start ()
    {
        backgroundQueue = new Queue<GameObject>();

        //inital number of BGs placed in the scene
        numBackgroundsSpawned = 4;

        //fill background queue with preinstantiated backgrounds
        while (backgroundQueue.Count < backgroundQueueBuffer)
        {
            var bg = (GameObject)Instantiate(backgroundToSpawn);
            backgroundQueue.Enqueue(bg);
            bg.SetActive(false);
        }

		//perform inital spawning
		while (numBackgroundsSpawned < numBackgroundsToSpawn) 
		{
			SpawnBackground ();	
		}

    }
    
    void Update ()
    {
        if (numBackgroundsSpawned < numBackgroundsToSpawn)
        {
            SpawnBackground();
        }
    }

    void SpawnBackground ()
    {
        if (backgroundQueue.Count > 0)
        {
            GameObject bg = backgroundQueue.Dequeue();
            //spawn ahead of last sprite by sprite size = 48.6f
            //y value is 1.11 to prevent vertical tearing - I have no idea why it is tearing though.
            float newXPosition = lastSpawnedBackground.position.x + 48.6f;
            bg.transform.position = new Vector3(newXPosition, 0, 0);
            lastSpawnedBackground = bg.transform;
            bg.SetActive(true);
            numBackgroundsSpawned++;
        }
    }

    public void EnqueueBackground(GameObject background)
    {
        backgroundQueue.Enqueue(background);
        numBackgroundsSpawned--;
        background.SetActive(false);
    }


}
