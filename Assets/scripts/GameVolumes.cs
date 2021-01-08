using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVolumes : MonoBehaviour
{
    public AudioSource gameVolume;

    private void Start()
    {
        gameVolume.Play();
    }

    void Update()
    {
        if (pausing.ispaused)
        {
            
            gameVolume.Pause();
        }
        else
        {
            gameVolume.UnPause();
        }
    }
}
