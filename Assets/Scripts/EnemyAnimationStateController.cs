using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationStateController : MonoBehaviour
{   
    // Start is called before the first frame update
    private Animator animator;
    public bool playerInAttackRange, playerInSightRange, isDead, walkPointSet;
    private bool stopAnimation; 

    void Start()
    {
        animator = GetComponent<Animator>();
        stopAnimation = false; 
    }

    // Update is called once per frame
    void Update()
    {
        //get the bools from AIEnemy.cs
        playerInAttackRange = GetComponent<AIEnemy>().playerInAttackRange;
        playerInSightRange = GetComponent<AIEnemy>().playerInSightRange;
        isDead = GetComponent<Enemy>().isDead;
        walkPointSet = GetComponent<AIEnemy>().walkPointSet;
        if (stopAnimation)
        {
            Invoke(nameof(KillAnimator), 200f);

        }

        if (isDead)
        {
            animator.SetBool("isChase", false);
            animator.SetBool("isShooting", false);
            animator.SetBool("isPatrol", false);
            animator.SetBool("isDead", true);
            animator.SetBool("isStand", false);
            stopAnimation = true; 
        }
        else if (!playerInAttackRange && playerInSightRange)
        {
            animator.SetBool("isChase", true);
            animator.SetBool("isShooting", false);
            animator.SetBool("isPatrol", false);
            animator.SetBool("isDead", false);
            animator.SetBool("isStand", false);
        }
        else if (playerInAttackRange && playerInSightRange)
        {
            animator.SetBool("isChase", false);
            animator.SetBool("isShooting", true);
            animator.SetBool("isPatrol", false);
            animator.SetBool("isDead", false);
            animator.SetBool("isStand", false);
        }
        else if (!playerInAttackRange && !playerInSightRange)
        {
            animator.SetBool("isChase", false);
            animator.SetBool("isShooting", false);
            animator.SetBool("isDead", false);

            if (walkPointSet)
            {
                animator.SetBool("isPatrol", true);
                animator.SetBool("isStand", false);
            }
            else
            {
                animator.SetBool("isPatrol", false);
                animator.SetBool("isStand", true);
            }
        }



    }

    void KillAnimator()
    {
        GetComponent<Animator>().enabled = false;

    }
}
