using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class sliderscript : MonoBehaviour
{
    public AudioMixer audiomixer,inGameMixer;
    public void setVolume(float volume)
    {
        audiomixer.SetFloat("Music",Mathf.Log10(volume)*20);
    }

    public void setInGameSounds(float volum)
    {
        inGameMixer.SetFloat("Sounds", Mathf.Log10(volum) * 20);
    }
}
