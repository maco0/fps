using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    
    bool gaisrola;
    public bool papaw;
    public static int sicocxleebsRaodenoba=0;
    //controli
    public static PlayerController instance;
   public Rigidbody2D theRB;
    public  int minuspoint=5;
    public static int minusmoxvda=0;
    public float nextfire;
    public float rate;
   public float moveSpeed;
   public float shiftingspeed;
   private Vector2 moveInput;
   private Vector2 mouseInput;
   public float minangle=10f;
   public float maxangle=160f;
    //camera
    public float sensitivity = 100f;

    public Camera cameraView;
    //tyviebi
    public GameObject bullet;
    public int currentAmmo;
    public int currentAmmo1=5;
    public int tyvia1=1;
    public int tyvia2=3;
    //animaciebi modzraobis
    public Animator red;
    public Animator movin;
    public Animator transitor;
    public Animator low;
    public Animator first;
    public Animator second;
    public Animator dabrunda;
   
    public Animator heals;
    //srolis animaciebi
    public Animator pew;
    public Animator headshot1;
    public Animator headShot;
    public Animator headshot2;
    public Animator headshot3;
    public Animator reloading;
    //sicocxle
    
    public int currentHealth;
    public int maxHealth=100;
    public float rame=1f;
    public Text healthText , ammoText,sicocxletext;
    public float range = 5f;

    //audio
    public AudioSource moxvda;
    public AudioSource ded;
    public AudioSource isrola;
    public AudioSource daihila;
    public AudioSource reload;
    
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        sicocxletext.text = sicocxleebsRaodenoba.ToString();

        currentHealth = maxHealth;
        healthText.text = currentHealth.ToString() + "%";
        ammoText.text = currentAmmo.ToString();
    }


    void Update()
    {
        if (!pausing.ispaused)
        {
            
            //player movement
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            Vector3 horizontal = transform.up * -moveInput.x;

            Vector3 vertical = transform.right * moveInput.y;

            
          
            theRB.velocity = (horizontal + vertical) * moveSpeed;
               
            
            //camera controller

            mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * sensitivity;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);
            Vector3 rotAmount = cameraView.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f);
            cameraView.transform.localRotation = Quaternion.Euler(rotAmount.x, Mathf.Clamp(rotAmount.y, minangle, maxangle), rotAmount.z);
            //shooting
            if (gunPickUp.ipova)
            {
                pew.SetBool("ipova", true);
                tyvia1 = tyvia2;
                papaw = true;
               
            }
            if (gaisrola)
            {
                StartCoroutine(gadatenva());
                gaisrola = false;
                
                return;
            }
            if (Input.GetMouseButtonDown(0)&&Time.time>nextfire)
            {
                nextfire = Time.time + rate;
                if (currentAmmo > 0)
                {
                    
                    isrola.Play();
                    gaisrola = true;
                    Ray ray = cameraView.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, range))
                    {

                        Instantiate(bullet, hit.point, transform.rotation);

                        if (hit.transform.tag == "Enemy")
                        {

                            hit.transform.parent.GetComponent<EnemyController>().takeDmg(tyvia1);

                        }
                        

                    }


                    else
                    {
                        Debug.Log("nothing");
                    }
                    currentAmmo--;


                    if (papaw)
                    {
                        pew.SetTrigger("srola");
                        Debug.Log("tf");
                    }
                    else
                    {
                        pew.SetTrigger("shoot");
                        Debug.Log("wtd");
                    }
                    if (currentHealth > 75 && currentHealth <= 100)
                    {
                        headShot.SetTrigger("gaisrola");
                    }
                    if (currentHealth > 50 && currentHealth <= 75)
                    {
                        headshot1.SetTrigger("gaisrola1");
                    }
                    if (currentHealth > 25 && currentHealth <= 50)
                    {
                        headshot2.SetTrigger("gaisrola2");
                    }
                    if (currentHealth > 0 && currentHealth <= 25)
                    {
                        headshot3.SetTrigger("gaisrola3");
                    }
                    ammoUI();
                }
            }


            // camera movement
            if (moveInput != Vector2.zero)
            {
                movin.SetBool("moves", true);
                
            }
            else
            {
                movin.SetBool("moves", false);
               
            }

        }
       
    }
    // player health impact code area
    public void takeDmg(int amount)
    {
        red.SetTrigger("moxvda");
        currentHealth -= amount;
        scoremanager.score -= minuspoint;
        minusmoxvda++;
        if (scoremanager.score < 0)
        {
            scoremanager.score = 0;
        }
        moxvda.Play();
        if (currentHealth < 75 && currentHealth > 50)
        {
            first.SetBool("first", true);
        }
        if (currentHealth < 50 && currentHealth > 25)
        {
            second.SetBool("second", true);
        }
        if (currentHealth < 25)
        {
            low.SetBool("low", true);
        }

        if (currentHealth <= 0)
        {
            if (sicocxleebsRaodenoba > 0)
            {
                AddHealth(100);
                sicocxleebsRaodenoba -= 1;
                sicocxletext.text = sicocxleebsRaodenoba.ToString();
                // dabrunda.SetBool("dabrunda", true);
                first.SetBool("first", false);
                second.SetBool("second", false);
                low.SetBool("low", false);

            }
            else
            {
                ded.Play();
                StartCoroutine(loadlevel(5));

                currentHealth = 0;
            }
        }
        healthText.text = currentHealth.ToString() + "%";
        
    }
   

    public void AddHealth(int heal)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += heal;
           heals.SetTrigger("heal");
            daihila.Play();

            if (currentHealth <=100  && currentHealth >= 75)
            {
                first.SetBool("first", false);
            }
            if (currentHealth <75 && currentHealth >= 50)
            {
                second.SetBool("second", false);
            }
            if (currentHealth< 50 &&currentHealth >= 25)
            {
                low.SetBool("low", false);
            }



            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            healthText.text = currentHealth.ToString() + "%";

        }
    }

    //ammo ui
    public void ammoUI()
    {
        
        ammoText.text = currentAmmo.ToString();

    }

    IEnumerator loadlevel(int level)
    {
        transitor.SetTrigger("start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(level);
        Time.timeScale = 1f;
    }

    IEnumerator gadatenva()
    {
        reloading.SetBool("reloading",true);
        reload.Play();
        yield return new WaitForSeconds(5);
        

    }


    public void sicocxlepickup(int extra)
    {
        sicocxleebsRaodenoba += extra;
        sicocxletext.text = sicocxleebsRaodenoba.ToString();
        heals.SetTrigger("heal");

    }
}
