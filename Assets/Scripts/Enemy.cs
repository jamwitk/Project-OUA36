using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    private Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    public Animator anim;
    public float reloadtime = 5f;

    public float health;

    private bool isDead = false;

    public GameObject projectile;
    public Transform firePoint;
    public float projectileSpeed;
    AudioSource audioSource;



    public bool seen = false;

    //Attacking
    public float timeBetweenAttacks;

    bool alreadyAttacked;
    // public GameObject projectile;

    //States
    public float sightRange, attackRange, AreaRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!isDead)
        {
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);


            if ((playerInSightRange && !playerInAttackRange) || (seen && !playerInAttackRange)) ChasePlayer();
            if ((playerInAttackRange)) AttackPlayer();
        }
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
            if (!isDead)
            {
                Vector3 direction = (player.transform.position - firePoint.position).normalized;
                direction.y = 0f;
                GameObject bullet = Instantiate(projectile, firePoint.position, Quaternion.identity);
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                bulletRigidbody.velocity = direction * projectileSpeed;


                anim.SetBool("attack", true);
                anim.SetBool("walk", false);
                seen = true;  


                ///End of attack code
                // Destroy(rb.gameObject, 2f);
                alreadyAttacked = true;
                audioSource.Play();

                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void Damage(float amount)
    {
        if (!isDead) // Kontrol ekle
        {
            health -= amount;
            seen = true;

            if (health <= 0)
            {
                isDead = true; // �l�m durumunu i�aretle
                Invoke(nameof(DestroyEnemy), 0f);
            }
        }
    }

    private void DestroyEnemy()
    {
        anim.SetTrigger("die");
        anim.SetBool("attack", false);
        anim.SetBool("walk", false);
        Destroy(gameObject, 2f);
    }
}