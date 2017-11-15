using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour {

    public GameObject coin;

	// Use this for initialization
	void Start () {
        Instantiate(coin);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
