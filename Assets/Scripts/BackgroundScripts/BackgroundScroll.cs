using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {
    [SerializeField]
    float speed = 0;
    float pos;
    bool shouldMove;

    private void OnEnable()
    {
        StartMove();
    }

    private void Start()
    {
        StartMove();
    }

    void Update()
    {
        if (shouldMove)
        {
            pos += speed;
            transform.position = new Vector3(pos, transform.position.y, transform.position.z);
        }
    }
       


    void StartMove()
    {
        pos = transform.position.x;
        shouldMove = true;
    }

    public void StopMove()
    {
        shouldMove = false;
        pos = 0;
    }


}
