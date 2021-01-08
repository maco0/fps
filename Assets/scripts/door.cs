using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Transform doorModel;
    public GameObject color;
    public bool labdoor;
    public bool firstdoor;
    private bool shouldOpen;
    public float openSpeed;
    public AudioSource doorebi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldOpen && doorModel.position.z != 1f)
        {
            doorModel.position = Vector3.MoveTowards(doorModel.position, new Vector3(doorModel.position.x,  doorModel.position.y,1f), openSpeed * Time.deltaTime);
            if (doorModel.position.z == 1f)
            {
                color.SetActive(false);
            }
        }
        else if (!shouldOpen && doorModel.position.z != 0f)
        {
            doorModel.position = Vector3.MoveTowards(doorModel.position, new Vector3(doorModel.position.x,  doorModel.position.y,0f), openSpeed * Time.deltaTime);
            if (doorModel.position.z == 0f)
            {
                color.SetActive(true);
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (labdoor)
        {
            if(other.tag=="Player"&& keyscript.gaago == true)
            {
                shouldOpen = true;
            }
        }
        else
         if (firstdoor)
        {
            if (other.tag == "Player" && gamgebi.firstroomdoor==true)
            {
                doorebi.Play();
                shouldOpen = true;
            }
        }
        else
         if (other.tag == "Player")
        {
            doorebi.Play();
            shouldOpen = true;
        }
        else if (other.tag == "Enemy")
        {
            shouldOpen = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            doorebi.Play();
            shouldOpen = false;
        }
    }
    
}
