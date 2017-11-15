using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInflightController : MonoBehaviour
{
    [SerializeField]
    float force = 200f;
    GameObject playerObject;
    Rigidbody2D playerRigidBody;
    bool isDiving;

    void Start ()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerRigidBody = playerObject.GetComponent<Rigidbody2D>();
    }
    
    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerObject.transform.Rotate(new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, 35f));
            playerRigidBody.AddForce(Vector2.down * force);
            isDiving = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "enemy":
                Debug.Log("You hit an enemy");
                if (isDiving)
                {
                    gameObject.transform.Rotate(0, 0, -35f);
                    playerRigidBody.AddForce(Vector2.up * 50f);
                    isDiving = false;
                }
                
                break;
            case "Ground":
                Debug.Log("You hit the ground");
                break;
            default:
                break;
        }
    }
}
