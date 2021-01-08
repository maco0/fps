using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class StartMenu : MonoBehaviour
{

  
    public AudioSource laugh;
    public AudioSource cracc;
    public Animator transition;
    public int time=1;
    
     void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
   }
    public void start()
    {
        laugh.Play();
        scoremanager.score = 0;
        StartCoroutine(loadlevel(1));
        Time.timeScale = 1f;
    }
    public void start2()
    {
        laugh.Play();
        scoremanager.score = 0;
        StartCoroutine(loadlevel(2));
        Time.timeScale = 1f;
    }

    public void start3()
    {
        laugh.Play();
        scoremanager.score = 0;
        StartCoroutine(loadlevel(3));
        Time.timeScale = 1f;
    }
    public void start4()
    {
        laugh.Play();
        scoremanager.score = 0;
        StartCoroutine(loadlevel(4));
        Time.timeScale = 1f;
    }

    public void quit()
    {
        cracc.Play();
        Application.Quit();
    }

    public void back()
    {
        cracc.Play();
    }
    public void mainmenu()
    {
        laugh.Play();
        scoremanager.score = 0;
        StartCoroutine(loadlevel(0));
        Time.timeScale = 1f;
    }


    IEnumerator loadlevel( int name)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(name);
       
    }
}
