using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> backgroundsToSpawn;
    [SerializeField]
    int backgroundBuffer = 1;
    Queue<GameObject> backgroundQueue;

    void Start ()
    {
        backgroundQueue = new Queue<GameObject>();
        foreach (var bg in backgroundsToSpawn)
        {
            for (int i = 0; i < backgroundBuffer; i++)
            {
                GameObject newBackground = (GameObject)Instantiate(bg);
                newBackground.SetActive(false);
                backgroundQueue.Enqueue(newBackground);
            }
        }
    }
    
    void Update ()
    {
        while (backgroundQueue.Count != 0)
        {
            var backgroundToSpawn = backgroundQueue.Dequeue();
            backgroundToSpawn.transform.position = new Vector3(transform.position.x, transform.position.y);
            backgroundToSpawn.SetActive(true);
        }
    }

    public void QueueBackground(GameObject background)
    {
        backgroundQueue.Enqueue(background);
    }
}
