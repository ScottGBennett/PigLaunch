using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrainPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.y > 2.9f) 
		{
			transform.position = new Vector3(transform.position.x, 2.9f);
		}
	}
}
