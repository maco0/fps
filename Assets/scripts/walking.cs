using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walking : MonoBehaviour
{
  
    
    PlayerController pc;
    public AudioSource audioe;
    void Start()
    {
        pc = GetComponent<PlayerController>();
    }

     void Update()
    {
        if (pc.theRB.velocity.magnitude > 2f && audioe.isPlaying == false)
        {
            if (!pausing.ispaused)
            {
                audioe.Play();
            }
            }
    }
    
}
