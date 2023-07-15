using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerStart : MonoBehaviour
{
  [SerializeField]  private PlayableDirector _playableDirevtor;
    void Start()
    {
       
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playableDirevtor.Play();
        }
    }
    void Update()
    {
        
    }
}
