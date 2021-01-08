using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamgebi : MonoBehaviour
{

    public static bool firstroomdoor;
    public AudioSource enemy;
    public AudioSource karigaigo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (!firstroomdoor)
            {
                karigaigo.Play();
            }
            firstroomdoor = true;
        }
        else if (collision.tag == "Player")
        {
            if (!firstroomdoor)
            {
                enemy.Play();
            }
        }
    }
    
}
