using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class enemySpawner : MonoBehaviour
{
    public AudioSource daspawneba;
    public GameObject winmenunotboss;
    public menu menu;
    bool daamtavra=false;
    public enum spawnState { spawning,waiting,counting};
    [System.Serializable]
    public class wave
    {  
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }
   
    public wave[] waves;
   
    private int nextWave = 0;

    public int boss=0;

    public Transform[] spawnpoint;

    public float timeBetween = 5f;
    public float waveCountDown = 0f;
    private spawnState state = spawnState.counting;
    public static bool moigo;
    private float searchCountDown=1f;
    void Start()
    {
        waveCountDown = timeBetween;
    }
   
    private IEnumerator newscene()
    {
        yield return new WaitForSeconds(1);
        winmenunotboss.SetActive(true);
        moigo = true;
        menu.winlevel();
        pausing.ispaused = true;
        daamtavra = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
      

    }
    void Update()
    {
        if (state == spawnState.waiting)
        {
            if (!enemyisAlive())
            {
                waveCompleted();
            }
            else
            {
                return;
            }
        }
        if (waveCountDown <= 0)
        {
            if(state!= spawnState.spawning)
            {
                if (!daamtavra)
                {
                    StartCoroutine(spawnwave(waves[nextWave]));
                }
                }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }
    void waveCompleted()
    {
        state = spawnState.counting;
        waveCountDown = timeBetween;
     
        if (nextWave + 1 > waves.Length - 1)
        {

           
                nextWave = 0;
                StartCoroutine(newscene());
                
        }
        else
        {
            nextWave++;
        }
    }
    bool enemyisAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }
    IEnumerator spawnwave( wave _wave)
    {
        state = spawnState.spawning;
        for(int i = 0; i < _wave.count; i++)
        {
            spawnenemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        state = spawnState.waiting;
        yield break;
    }

    void spawnenemy(Transform _enemy)
    {
        if (spawnpoint.Length == 0)
        {
            Debug.Log("there  aint chief");
        }
        daspawneba.Play();
        Transform _sp = spawnpoint[Random.Range(0, spawnpoint.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}
