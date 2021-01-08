using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static bool ispaused = false;
    public GameObject PauseMenuUi;

    void Start()
    {
        lockcursor();
        ispaused = false;

    }
   
    void Update()
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

    public void resume()
    {
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
}
