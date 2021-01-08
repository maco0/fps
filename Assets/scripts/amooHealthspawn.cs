using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amooHealthspawn : MonoBehaviour
{
    public Transform health;
    public Transform[] spawnpointebi;
    float timer = 0;
    public float delay;
    public string name;
    public AudioSource spawnsounds;
     void Update()
    {
        if (timer >= delay)
        {
            timer -= delay;
            if (GameObject.FindGameObjectWithTag(name) == null)
            {
                spawnsounds.Play();
                spawnbuffs(health);
            }
            
        }
        timer += Time.deltaTime;
    }




    void spawnbuffs(Transform _enemy)
    {
        if (spawnpointebi.Length == 0)
        {
            Debug.Log("there  aint chief");
        }
        Transform _sp = spawnpointebi[Random.Range(0, spawnpointebi.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}
