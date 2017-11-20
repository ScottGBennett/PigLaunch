using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField]
    public float maxSpeed = 5f;

    float speed ;
	public bool isAlive;

    Animator animator;
     
    void Start ()
    {
        isAlive = true;
        animator = GetComponentInChildren<Animator>();
        speed = Random.Range(1f, maxSpeed);
        
    }

	void OnEnable()
	{
		isAlive = true;
        animator = GetComponentInChildren<Animator>();
        animator.Rebind();
        speed = Random.Range(1f, maxSpeed);
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
