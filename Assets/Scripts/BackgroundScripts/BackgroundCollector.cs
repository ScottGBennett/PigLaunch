using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCollector : MonoBehaviour {

    GameObject backgroundSpawner;
    BackgroundSpawner bgSpawner;
    Camera mainCamera;
    GameObject cameraObject;
    Renderer bgRenderer;
    

    // Use this for initialization
    void Start ()
    {
        bgRenderer = GetComponent<Renderer>();
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        mainCamera = cameraObject.GetComponent<Camera>();
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
