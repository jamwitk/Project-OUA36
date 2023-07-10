using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    private Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    // public bool dead = false;
    public Animator anim;
    public float reloadtime = 5f;

    public float health;


    

    public bool seen = false;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    // public GameObject projectile;

    //States
    public float sightRange, attackRange,AreaRange;
    public bool playerInSightRange, playerInAttackRange,PlayerinAttackArea;

    private void Awake()
    {



        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        PlayerinAttackArea = Physics.CheckSphere(transform.position, AreaRange, whatIsPlayer);



        if ((playerInSightRange && !playerInAttackRange && !PlayerinAttackArea) || (seen && !playerInAttackRange && !PlayerinAttackArea)) ChasePlayer();
        if ((playerInAttackRange) || (seen && PlayerinAttackArea)) AttackPlayer();
    }

    private void ChasePlayer()
    {

        Debug.Log("Following");
        anim.SetBool("walk", true);
        anim.SetBool("attack", false);
        agent.SetDestination(player.position);




    }
    private void AttackPlayer()
    {




        //Make sure enemy doesn't move


        transform.LookAt(player);

        agent.SetDestination(transform.position);

        if (!alreadyAttacked)
        {
            ///Attack code here
            // Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            /// rb.AddForce(transform.forward * 60f, ForceMode.Impulse);
            // rb.AddForce(transform.up * 3.5f, ForceMode.Impulse);
            //anim.SetBool("walking", false);
            // anim.SetTrigger("ates");
            Debug.Log("Attacked");
            anim.SetBool("attack", true);
            anim.SetBool("walk", false);
            seen = true;

            ///End of attack code
            // Destroy(rb.gameObject, 2f);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    private void ResetAttack()
    {


        alreadyAttacked = false;
    }
    public void Damage(float amount)
    {

        health -= amount;
        seen = true;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject, 2.5f);
    }
}
