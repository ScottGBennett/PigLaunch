using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCollector : MonoBehaviour {
    [SerializeField]
    GameObject backgroundSpawner;
    BackgroundSpawner bgSpawner;

    // Use this for initialization
    void Start ()
    {
        bgSpawner = backgroundSpawner.GetComponent<BackgroundSpawner>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Background")
        {
            var bgScroll = collision.gameObject.GetComponent<BackgroundScroll>();
            bgScroll.StopMove();
            collision.gameObject.SetActive(false);
            bgSpawner.QueueBackground(collision.gameObject);
            
        }
    }
}
