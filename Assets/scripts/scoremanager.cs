using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class scoremanager : MonoBehaviour
{
    
    public static int score;
    public Text text;
    public static float timer;

     void Update()
    {
        timer += Time.deltaTime;
        text.text =score.ToString();
    }
}
