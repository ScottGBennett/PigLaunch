using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float maxStretch = 3.0f;
    public float freq = 2.5f;
    public float attackForce = 1f;
    public int maxNumAttacks = 2;
    public LineRenderer catapultLineFront;
    public LineRenderer catapultLineBack;
    public LaunchController gameController;
    public AudioController audioController;

    private int currentNumAttacks = 0;
    private SpringJoint2D spring;
    private Transform catapult;
    private Rigidbody2D rb2d;
    private Ray leftCatapultToProjectile;
    private CircleCollider2D circle;
    private float circleRadius;
    private bool clickedOn;
    private Vector2 prevVelocity;
    private GameStateController gameStateController;
    StoreState storeState;

    private void Start()
    {
        gameStateController = GameObject.FindGameObjectWithTag("GameStateController").GetComponent<GameStateController>();
    }

    void Awake()
    {
        spring = GetComponent<SpringJoint2D>();
        rb2d = GetComponent<Rigidbody2D>();
        catapult = spring.connectedBody.transform;

        //get current state from player prefs
        string storeStateString = PlayerPrefs.GetString("StoreState");
        storeState = JsonUtility.FromJson<StoreState>(storeStateString);

        maxNumAttacks = storeState.numAttacksLevel; //set the number of attacks
    }

    void Update () 
    {

        //If launch has happened, allow for pig attack
        if (gameController.launched && rb2d.velocity != Vector2.zero) 
        {
            if (Input.GetButtonDown("Fire1") && !gameStateController.gameOver && currentNumAttacks < maxNumAttacks) 
            {
                BasicAttack ();
                currentNumAttacks++;
            }	
        }

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

        //constrain player sprite to just above screen
        if (transform.position.y > 2.6f) 
        {
            transform.position = new Vector3(transform.position.x, 2.6f);
        }

        //check for gameover condition
        if (rb2d.velocity == Vector2.zero && gameController.launched)
        {
            gameStateController.gameOver = true;
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

    private void BasicAttack()
    {
        rb2d.AddForce (Vector2.down * attackForce, ForceMode2D.Impulse);
        audioController.PlayPigSound();
    }
}
