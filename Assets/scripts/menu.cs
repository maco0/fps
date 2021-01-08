using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using JetBrains.Annotations;
using UnityEngine.UI;
public class menu : MonoBehaviour
{
    public AudioSource hell;
    public AudioSource laugh;
    public AudioSource cracc;
    public int scenisIndex;
    public Text scoring;
    public Animator transitor;
    public Text time;
    public GameObject button;
    public Text minus;
    public Text timename;
    public Text gothit;
    public Text finalscore;
    
    public int gaxsnaturi;
    void Start()
    {
        transitor.SetTrigger("start");
      Cursor.lockState=  CursorLockMode.None;
        Cursor.visible = true;
        StartCoroutine(showtext());
        StartCoroutine(showbutton());
    }
    public void retry()
    {
        laugh.Play();
        StartCoroutine(loadlevel(1));
        Time.timeScale = 1f;
        scoremanager.score = 0;
        enemySpawner.moigo = false;
    }
    
    public void mainmenu()
    {
        hell.Play();
        StartCoroutine(loadlevel(0));
        Time.timeScale = 1f;
        enemySpawner.moigo = false;
    }

    public  void quit()

    {
        cracc.Play();
        Application.Quit();
    }

    public void nextlevel()
    {
        cracc.Play();
        StartCoroutine(loadlevel(scenisIndex));
        Time.timeScale = 1f;
        enemySpawner.moigo = false;
    }


    IEnumerator loadlevel(int level)
    {

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(level);
    }

  IEnumerator showtext()
    {
        yield return new WaitForSeconds(5);
        scoring.text = scoremanager.score.ToString();
        time.text = scoremanager.timer.ToString();
        minus.text = PlayerController.minusmoxvda.ToString();
        timename.text = "TIME";
        gothit.text = "GOT HIT";
        finalscore.text = "FINALSCORE";
    }
    IEnumerator showbutton()
    {
        yield return new WaitForSeconds(7);
        button.SetActive(true);
    }


    public void winlevel()
    {
        PlayerPrefs.SetInt("levelReached", gaxsnaturi);

    }
}
