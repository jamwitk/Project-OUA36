using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PuzzlePlace"))
        {
            var placeName = other.gameObject.name.Split('-')[1];
            if (placeName == gameObject.name.Split('-')[1])
            {
                other.gameObject.GetComponent<PuzzlePlace>().Done();
                gameObject.tag = "Untagged";
                Destroy(gameObject.GetComponent<Rigidbody>());
                //done
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("PuzzlePlace"))
        {
            var placeName = other.gameObject.name.Split('-')[1];
            if (placeName == gameObject.name.Split('-')[1])
            {
                //done
                other.gameObject.GetComponent<PuzzlePlace>().UnDone();
            }
        }
    }

}
