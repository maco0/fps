using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poison : MonoBehaviour
{
    public int damage;
    public float delay;
    float timer;
    PlayerController pleer;

    private void Awake()
    {
        pleer = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pleer.takeDmg(damage);
        }
    }

   private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (timer >= delay)
            {
                timer -= delay;
                pleer.takeDmg(damage);
            }
            timer += Time.deltaTime;
        }
    }
   
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            timer = 0;
        }
    }
}
