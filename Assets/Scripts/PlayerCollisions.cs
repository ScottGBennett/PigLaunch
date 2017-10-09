using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour 
{
	[SerializeField]
	Rigidbody2D playerRigidBody;
	[SerializeField]
	float speed = 1f;
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground") 
		{
			transform.Rotate (0, 0, 0);
			playerRigidBody.AddForce  (Vector2.up * speed);

		}
		else if (collision.gameObject.tag == "enemy")
		{
			transform.Rotate (0, 0, 0);
			playerRigidBody.AddForce (Vector2.up * speed);
		}
	}


}
