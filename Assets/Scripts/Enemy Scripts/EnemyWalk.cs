using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField]
    int speed = 1;
    bool isAlive;
    Animator animator;
     
    public void SetIsAlive(bool value)
    {
        isAlive = value;
    }
    void Start ()
    {
        isAlive = true;
        animator = GetComponentInChildren<Animator>();
        
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
