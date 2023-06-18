using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Vector3 spawnpoint;
    public static bool dead = false;

    void Start()
    {
        spawnpoint = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == true)
        {
            Respawn();
        }

        if (gameObject.transform.position.y <= -10f)
        {
            Respawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "checkpoint")
        {
            spawnpoint = other.gameObject.transform.position;
        }
    }

    void Respawn()
    {
        gameObject.transform.position = spawnpoint;
        dead = false;
    }
}