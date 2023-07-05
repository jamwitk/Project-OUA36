using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public AudioSource BgAudio;
    // Start is called before the first frame update
    void Start()
    {
        BgAudio.Play();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
