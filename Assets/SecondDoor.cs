using System;
using System.Collections;
using System.Collections.Generic;
using Puzzle;
using UnityEngine;

public class SecondDoor : MonoBehaviour
{
    public MagaraPuzzle magaraPuzzle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            magaraPuzzle.doorAnimator.SetTrigger("SecondDoor");
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
