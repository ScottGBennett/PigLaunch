using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxStretch = 3.0f;
    public LineRenderer catapultLineFront;
    public LineRenderer catapultLineBack;

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
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (spring != null)
        {
            if (!rb2d.isKinematic && prevVelocity.sqrMagnitude > rb2d.velocity.sqrMagnitude)
            {
                Destroy(spring);
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

    private void OnMouseDown()
    {
        spring.enabled = false;
        clickedOn = true;
    }

    private void OnMouseUp()
    {
        spring.enabled = true;
        rb2d.isKinematic = false;
        rb2d.angularDrag = 1f;
        rb2d.drag = 0.3f;
        rb2d.gravityScale = 1f;
        rb2d.mass = 5;
        clickedOn = false;
    }

}
