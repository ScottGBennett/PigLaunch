using UnityEngine;
using System.Collections;

public class BackgroundTiler : MonoBehaviour
{
    
    public float speed = 0;
    [SerializeField]
    float tileSize = 0;
    float pos = 0;



    void Update()
    {
        

        pos += speed;
        if (pos < -tileSize)
            pos += tileSize;

        gameObject.transform.position = new Vector3(pos, gameObject.transform.position.y);
    }
}