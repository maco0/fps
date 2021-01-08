using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyscript : MonoBehaviour
{
    public static bool gaago=false;
    public AudioSource gasag;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gasag.Play();
            gaago = true;
            Destroy(gameObject,0.5f);
        }
    }
}
