using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPIckUp : MonoBehaviour
{
    public int ammoAmount = 25;
    public static bool amoi = false;
    public AudioSource ammo;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            ammo.Play();
            PlayerController.instance.currentAmmo += ammoAmount;
            PlayerController.instance.ammoUI();
            amoi = true;
            Destroy(gameObject,0.5f);
           
        }
        amoi = false;
    }
}
