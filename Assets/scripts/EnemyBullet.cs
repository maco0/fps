using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damageAmount;

    public float bulletSpeed = 5f;
    public Rigidbody2D bRb;

    private Vector3 direction;
    void Start()
    {
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
        direction = direction * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        bRb.velocity = direction * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController.instance.takeDmg(damageAmount);
            Destroy(gameObject);
        }
        else if (collision.tag == "Door")
        {
            Destroy(gameObject);
        }
        else if (collision.tag == "Walls")
        {
            Destroy(gameObject);
        }
    }
}
