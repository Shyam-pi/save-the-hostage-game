using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationStateController : MonoBehaviour
{   
    // Start is called before the first frame update
    private Animator animator;
    public bool playerInAttackRange, playerInSightRange;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //get the bools from AIEnemy.cs
        playerInAttackRange = GetComponent<AIEnemy>().playerInAttackRange;
        playerInSightRange = GetComponent<AIEnemy>().playerInSightRange;

        if (!playerInAttackRange && playerInSightRange)
        {
            animator.SetBool("isChase", true);
            animator.SetBool("isShooting", false);
            animator.SetBool("isPatrol", false);
        }
        else if (playerInAttackRange && playerInSightRange)
        {
            animator.SetBool("isChase", false);
            animator.SetBool("isShooting", true);
            animator.SetBool("isPatrol", false);
        }
        else if (!playerInAttackRange && !playerInSightRange)
        {
            animator.SetBool("isChase", false);
            animator.SetBool("isShooting", false);
            animator.SetBool("isPatrol", true);
        }


    }
}
