using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Unity.VisualScripting.Member;
using static UnityEngine.GraphicsBuffer;

public class AIEnemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public GameObject bullet; 

    private Vector3 walkPoint;
    bool walkPointSet;
    float walkPointRange;
    float health;

    float timeBetweenAttacks;
    bool alreadyAttacked;

    float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private float fireRate = 5000f;
    private float nextTimeToFire = 0.0f;
    RaycastHit playerhit;

    // Start is called before the first frame update
    void Start()
    {
        walkPoint = new Vector3(0, 0, 0);
        walkPointRange = 6;
        timeBetweenAttacks = 500f;
        sightRange = 15f;
        attackRange = 10f;
        walkPointSet = false;
        playerInSightRange = false;
        alreadyAttacked = false;
        playerInAttackRange = false;
        nextTimeToFire = Time.time + 1f / fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);



        if (!playerInAttackRange && !playerInSightRange)
        {
            Patrolling();
        } else if (!playerInAttackRange && playerInSightRange)
        {
            ChasePlayer();
        }
        else if (playerInAttackRange && playerInSightRange)
        {
            if (Physics.Linecast(transform.position, player.transform.position, out playerhit))
            {
                if (playerhit.transform.tag == "Wall")
                {
                    Debug.Log("I see the wall"); 
                   

                } else
                {
                    if (Time.time >= nextTimeToFire)
                    {
                        AttackPlayer();
                        nextTimeToFire = Time.time + 1f / fireRate;

                    }
                   
                    Debug.Log("I dont' see the wall");
                }
            }   

        }

    // //set y position to -1
    // transform.position = new Vector3(transform.position.x, -1, transform.position.z);

    }

    void Patrolling()
    {
        Debug.Log("Patrolling");
        if (!walkPointSet)
        {
            SearchWalkingPoint();

        }
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false; 
        }

    }

    void SearchWalkingPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true; 
        } 
    }

    void ChasePlayer()
    {
        Debug.Log("Chasing");
        agent.SetDestination(player.position);

    }

    void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        { 
            

            Debug.Log("Attack");
            GameObject bulletObject2 = Instantiate(bullet, transform.position + transform.forward * 1.5f, Quaternion.identity);
            bulletObject2.GetComponent<ProjectileController>().hitpoint = player.transform.position;

            
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    void ResetAttack()
    {
        alreadyAttacked = false;

    }
}
