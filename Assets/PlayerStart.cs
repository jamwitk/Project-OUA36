using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerStart : MonoBehaviour
{
  [SerializeField]  private PlayableDirector _playableDirevtor;
  public Animator BookUpAnim;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BookUpAnim.SetTrigger("BookUp");
            _playableDirevtor.Play();
        }
    }
    void Update()
    {
        
    }
}
