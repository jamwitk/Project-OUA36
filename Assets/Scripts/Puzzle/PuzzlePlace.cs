using System.Collections;
using System.Collections.Generic;
using Puzzle;
using UnityEngine;

public class PuzzlePlace : MonoBehaviour
{
    public GameObject symbol;
    public AudioClip Ses;
    
    public void Done()
    {
        MagaraPuzzle.Instance.PlaceRockCounter();
        symbol.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        //TODO:
        //animation?
        //sound?
      //  AudioSource.PlayClipAtPoint(Ses, transform.position);
        //particle?
    }

    public void UnDone()
    {
        MagaraPuzzle.Instance.UnPlaceRockCounter();
        symbol.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        //TODO:
        //geri alma animation?
        //geri alma sound?
        //geri alma particle?
    }
}
