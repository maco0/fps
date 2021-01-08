using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int HealthAmount = 20;
    PlayerController pleer;
   
    private void Awake()
    {
        pleer = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"&& pleer.currentHealth<100)
        {
                   
            
                PlayerController.instance.AddHealth(HealthAmount);

           
                Destroy(gameObject);
           
        }
    }

}
