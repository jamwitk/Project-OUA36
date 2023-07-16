using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerStart : MonoBehaviour
{
  [SerializeField]  private PlayableDirector _playableDirevtor;
  public Animator BookUpAnim;
  AudioSource audioSource;
  
  
    // Update is called once per frame
     void Start()
    {
        audioSource = GetComponent<AudioSource>();
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {       
            audioSource.Play();
            
            BookUpAnim.SetTrigger("BookUp");
            _playableDirevtor.Play();
        }
    }
  
}
