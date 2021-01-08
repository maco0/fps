using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunPickUp : MonoBehaviour
{
    public static bool ipova;
    PlayerController player;
    public int bonus = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.sicocxlepickup(bonus);
            Destroy(gameObject);
            
        }
    }
}
