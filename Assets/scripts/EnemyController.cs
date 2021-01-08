using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemyscore;
    public int health=3;
    public GameObject explosion;

    public float playerRange = 10f;
    public float shootRange = 5f;
    public Rigidbody2D theRB;
     bool shouldShoot;
    public float shootcounter;
    public float rate = 0.5f;
    public GameObject EnemyBullet;
    public Transform firepoint;
    public float moveSpeed;
    public Animator walk;
    public Animator shooting;
    public Animator hurt;

    public AudioSource shoot;
    public AudioSource hurtebi;
    
    public void takeDmg(int damage)
    {
        hurtebi.Play();
        health-=damage;
        hurt.SetTrigger("hurt");
        if(health<= 0)
        {
            hurtebi.Play();
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            scoremanager.score += enemyscore;
        }
    }
     void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange)
        {
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;
            theRB.velocity = playerDirection.normalized * moveSpeed;
            walk.SetBool("spot", true);
            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) <shootRange)
            {

                
                    shootcounter -= Time.deltaTime;
               
                    if (shootcounter <= 0)
                    {
                    shoot.Play();
                        Instantiate(EnemyBullet, firepoint.position, firepoint.rotation);
                        shootcounter = rate;
                     shooting.SetTrigger("pew");
                    }
                
                    theRB.velocity = playerDirection.normalized * 0f;
                walk.SetBool("spot", false);

            }
            
        }
        else
        {
            theRB.velocity = Vector2.zero;
            walk.SetBool("spot", false);
            //shooting.SetBool("shooting", false);

        }
    }
}
