using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class pausing : MonoBehaviour
{
    public AudioSource laugh;
    public AudioSource hell;
    public AudioSource cracc;
    public static bool ispaused = false;
    public GameObject PauseMenuUi;
    public Animator transitor;

    void Start()
    {
        lockcursor();
        ispaused = false;
       
    }

    void Update()
    {
        if (!enemySpawner.moigo)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (ispaused)
                {
                    resume();

                }
                else
                {
                    pause();
                }
            }
        }        
    }
    public void crack()
    {
        cracc.Play();
    }

    public void resume()
    {
        laugh.Play();
        lockcursor();
        PauseMenuUi.SetActive(false);
        ispaused = false;
        Time.timeScale = 1f;
    }
    public void pause()
    {
        unlock();
        PauseMenuUi.SetActive(true);
        ispaused = true;
        Time.timeScale = 0f;
       
    }
    private void lockcursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void unlock()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }




  public  void resumeButton()
    {
        
        resume();
    }



  public  void menu()
    {
        hell.Play();
        StartCoroutine(loadlevel(0));
        Time.timeScale = 1f;
    }
    public void paka()
    {
        cracc.Play();
        Application.Quit();
    }

    IEnumerator loadlevel(int level)
    {
        transitor.SetTrigger("start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(level);
    }
}
