using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float maxStretch = 3.0f;
    public LineRenderer catapultLineFront;
    public LineRenderer catapultLineBack;
    public float freq = 2.5f;

    private SpringJoint2D spring;
    private Transform catapult;
    private Rigidbody2D rb2d;
    private Ray leftCatapultToProjectile;
    private CircleCollider2D circle;
    private float circleRadius;
    private bool clickedOn;
    private Vector2 prevVelocity;

    void Awake()
    {
        spring = GetComponent<SpringJoint2D>();
        rb2d = GetComponent<Rigidbody2D>();
        catapult = spring.connectedBody.transform;
    }

    // Use this for initialization
    void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (spring != null)
        {
            //if the pig has been launched, destroy the spring and calculate velocity
            if (!rb2d.isKinematic && prevVelocity.sqrMagnitude > rb2d.velocity.sqrMagnitude)
            {
                Destroy(spring);
				spring = null;
                rb2d.velocity = prevVelocity;
            }

            if (!clickedOn)
                prevVelocity = rb2d.velocity;
        }

        else
        {
            catapultLineFront.enabled = false;
            catapultLineBack.enabled = false;
        }
	}

    public void Launch(float f)
    {
        //take user input and calculate spring frequency
        float maxFreq = 2.5f;
        float minFreq = 1.0f;
        //Frequency calc: user input from 1-100% * (max frequency - min frequency) + min frequency
        /*The idea is that the range is 1 - 2.5 for frequency. User input is from 1 - 100. Convert that to a 
              percentage to determine where between 1 and 2.5 the launch should be*/
        spring.frequency = ((f/100) * (maxFreq - minFreq)) + minFreq;

        spring.enabled = true;
        rb2d.isKinematic = false;
        rb2d.angularDrag = 1f;
        rb2d.drag = 0.3f;
        rb2d.gravityScale = 1f;
        rb2d.mass = 5;
        clickedOn = false;
    }

}
