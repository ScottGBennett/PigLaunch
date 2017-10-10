using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCollector : MonoBehaviour {

    GameObject backgroundSpawner;
    BackgroundSpawner bgSpawner;
    
    void Start ()
    {
        backgroundSpawner = GameObject.FindGameObjectWithTag("BackgroundSpawner");
        bgSpawner = backgroundSpawner.GetComponent<BackgroundSpawner>();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Trigger!");
        if (collision.gameObject.tag == "Background")
        {
           bgSpawner.EnqueueBackground(collision.gameObject);
        }
    }

}
