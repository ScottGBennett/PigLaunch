using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script only used for testing. do not use for gameplay.

public class PropelPig : MonoBehaviour {
    public float speed = 1f;

    Rigidbody2D rb;

    // Use this for initialization
    void Start ()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(speed, 0);
    }

}
