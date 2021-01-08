using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falsedoor : MonoBehaviour
{

    public GameObject lava;
    public Animator tilelava;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            tilelava.SetTrigger("daadga");
            StartCoroutine(lavaspawn());
            Destroy(gameObject, 2f); 

        }
    }


    IEnumerator lavaspawn()
    {
        yield return new WaitForSeconds(1);
        Instantiate(lava, transform.position, transform.rotation);
    }
}
