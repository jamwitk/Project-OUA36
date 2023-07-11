using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour
{
    private bool collided;
    private void OnCollisionEnter(Collision collision)
    {
        if((collision.gameObject.tag != "Player" && collision.gameObject.tag !="Bullet" && !collided))
            {
            collided = true;
            Destroy(gameObject);
        }
    }
}
