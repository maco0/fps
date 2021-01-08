using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class textscript : MonoBehaviour
{
    public string fulltext;
    public float speed=0.1f;
    string currentText;
    public int enemycount;
    void Start()
    {
        StartCoroutine(typewrighter());
       
    }
    IEnumerator typewrighter()
    {
        for (int i = 0; i < fulltext.Length; i++)
        {
            currentText = fulltext.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(speed);
        }

    }
}
