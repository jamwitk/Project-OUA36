using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour
{
    private bool collided;

    private void Start()
    {
        Destroy(this.gameObject, 2f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if((collision.gameObject.tag == "Player" && !collided))
            {
            collided = true;
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10);
                // Rakibin Playere vurdugu dmg
            }
            Destroy(gameObject);
        }
        else if((collision.gameObject.tag == "Enemy" && !collided))
        {
            collided = true;
            Enemy enemyHealth = collision.gameObject.GetComponent<Enemy>();
            if (enemyHealth != null)
            {
                enemyHealth.Damage(20);
                // Playerin rakibe vurdugu dmg
            }
            Destroy(gameObject);
        }
        else
        {
            collided = true;
            Destroy(gameObject);
        }
    }
}
