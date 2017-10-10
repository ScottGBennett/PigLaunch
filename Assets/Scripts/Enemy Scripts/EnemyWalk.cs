using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField]
    int speed = 1;

	public bool isAlive;

    Animator animator;
     
    void Start ()
    {
        isAlive = true;
        animator = GetComponentInChildren<Animator>();
        
    }

	void OnEnable()
	{
		isAlive = true;
	}
    
    // Update is called once per frame
    void Update ()
    {
        if (isAlive)
        {
            animator.Play("Move");
            gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
}
