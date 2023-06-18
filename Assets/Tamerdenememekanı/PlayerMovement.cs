using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float walk_speed, walkb_speed, walks_speed, run_speed, rotate_speed;
    public bool walking;
    public Transform playerTrans;

    public float Health;


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRigid.velocity = transform.forward * (walk_speed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerRigid.velocity = -transform.forward * (walkb_speed * Time.fixedDeltaTime);
        }
    }

    void Update()
    {
        if (Health <= 0)
        {
            Checkpoint.dead = true;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("walk");
            playerAnim.ResetTrigger("idle");
            playerAnim.ResetTrigger("walkback");
            playerAnim.ResetTrigger("run");
            walking = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("walk");
            playerAnim.SetTrigger("idle");
            playerAnim.ResetTrigger("walkback");
            playerAnim.ResetTrigger("run");

            walking = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("walkback");
            playerAnim.ResetTrigger("idle");
            playerAnim.ResetTrigger("walk");
            playerAnim.ResetTrigger("run");
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("walkback");
            playerAnim.SetTrigger("idle");
            playerAnim.ResetTrigger("walk");
            playerAnim.ResetTrigger("run");

            //steps1.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (walking == true)
            {
                walk_speed = run_speed;
                playerAnim.SetTrigger("run");
                playerAnim.ResetTrigger("walk");
                playerAnim.ResetTrigger("idle");
                playerAnim.ResetTrigger("walkback");
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            walk_speed = walks_speed;
            playerAnim.ResetTrigger("run");
            playerAnim.SetTrigger("walk");

            playerAnim.ResetTrigger("idle");
            playerAnim.ResetTrigger("walkback");
        }
    }


    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.rotation *= Quaternion.Euler(0, -rotate_speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.rotation *= Quaternion.Euler(0, rotate_speed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            this.Health -= 10;
        }
    }
}