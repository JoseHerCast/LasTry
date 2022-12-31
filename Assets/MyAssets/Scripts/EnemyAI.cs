using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    private Animator animator;
    public float walkingSpeed = 2.0f;
    public float runningSpeed = 5.0f;
    private bool isAware=false;
    private bool isNear = false;

    //for patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //for attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //for enemies states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake ()
    {
        player = GameObject.Find("Player1").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }
    //These are the enemies states functions
    private void Patrolling()
    {
        isAware = false;
        isNear = false;
        agent.speed = walkingSpeed;
        //print("patrolling...");
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet) { 
            agent.SetDestination(walkPoint);
            //print("walkpoint: "+walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //print("posición de agente: "+transform.position);
        //print("distancia hacia el walkpoint: " + distanceToWalkPoint);

        //when our walkpoint is reached
        if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
    }

    private void ChasePlayer()
    {
        isAware = true;
        isNear = false;
        agent.speed = runningSpeed;
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure that enemy does not move
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //Attack code
            //GameObject projectileClone = Instantiate(projectile, transform.position, Quaternion.identity);
            //projectileClone.SetActive(true);
            //Rigidbody rb = projectileClone.GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 32, ForceMode.Impulse);
            //rb.AddForce(transform.up * 5f, ForceMode.Impulse);
            isNear = true;
            isAware = false;

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

   
    private void onDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //print("Walkpoint: " + walkPoint);

        if (Physics.Raycast(walkPoint, -transform.up, 10f, whatIsGround)) {
            walkPointSet = true;
                //print("Walkpoint set: true");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!animator.GetBool("Die"))
        {

            animator.SetBool("Near", isNear);
            animator.SetBool("Aware", isAware);
            //Check for sight and attack range
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
            //There are 3 posibilities
            if (!playerInAttackRange && !playerInSightRange) Patrolling();//Just patrolling your area.
            if (!playerInAttackRange && playerInSightRange) ChasePlayer();//Chasing player.
            if (playerInAttackRange && playerInSightRange) AttackPlayer();//Just do it!.
        }
    }
}
