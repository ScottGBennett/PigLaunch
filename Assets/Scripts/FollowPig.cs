using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPig : MonoBehaviour {

    public Transform pig;
    public Transform farLeft;
    public Transform farRight;
	
	// Update is called once per frame
	void Update () {
        Vector3 newPosition = transform.position;
        newPosition.x = pig.position.x;
        //newPosition.x = Mathf.Clamp(newPosition.x, newPosition.x, farRight.position.x); //set the values
        newPosition.x = Mathf.Clamp(newPosition.x, farLeft.position.x, farRight.position.x);
        transform.position = newPosition;

        //move the left marker each frame 3 units behind the pig
        newPosition.x = pig.position.x - 3f; 
        farLeft.position = newPosition;

        //move the right marker each frame 7 units in front of the pig
        newPosition.x = pig.position.x + 7f;
        farRight.position = newPosition;
	}
}
