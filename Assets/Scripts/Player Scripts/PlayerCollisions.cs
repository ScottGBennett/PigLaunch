using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour 
{
	[SerializeField]
	Rigidbody2D playerRigidBody;
	[SerializeField]
	float groundBounceForce = 1f;
	[SerializeField]
	float enemyBounceForce = 1f;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground") 
		{
			transform.Rotate (0, 0, 0);
			playerRigidBody.AddForce  (Vector2.up * groundBounceForce, ForceMode2D.Impulse);

		}
		else if (collision.gameObject.tag == "enemy")
		{
			transform.Rotate (0, 0, 0);
			playerRigidBody.AddForce (Vector2.up * enemyBounceForce, ForceMode2D.Impulse);
		}
	}


}
