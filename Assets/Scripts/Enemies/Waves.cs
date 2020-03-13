using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Waves : MonoBehaviour
{
    public GameObject BasicCentrist;
    public GameObject RadicalCentrist;
    public GameObject AntiExtremist;
    public GameObject HorseshoeCentrist;

    Text waveText;
    Text tierText;

    bool nextWave;
    bool allReleased;

    public static int waveNo;
    public static int enemyMax;
    public static int enemyKilled;

    private void Start()
    {
        allReleased = false;
        waveText = GameObject.Find("WaveText").GetComponent<Text>();
        tierText = GameObject.Find("EnemyTierText").GetComponent<Text>();
        waveNo = 0;
        waveText.text = "Wave: " + (waveNo + 1).ToString();
        tierText.text = "Enemy Health: " + (GlobalVars.EnemyHealthPercent).ToString() + "%"; 
        StartCoroutine(SendWaves());
    }

    private void CountEnemies()
    {
        if (enemyMax == enemyKilled)
        {
            EndWave();
        }
    }

    private void Update()
    {
        if (allReleased == true)
        {
            CountEnemies();
        }
    }


    IEnumerator SpawnWaves(string centristType, int amount, string spacing, float time, bool last) //IEnumerator Allows me to pause the function after it's done to provide a "pause" between groups of enemies
    {
        tierText.text = "Enemy Health: " + (GlobalVars.EnemyHealthPercent).ToString() + "%";
        yield return new WaitUntil(() => nextWave);  //Lambda expression needed to convert to system.func(bool)
        yield return new WaitForSeconds(time);
        for (int i = 0; i <= amount; i++)
        {
            GameObject Enemy;
            if (centristType == "Basic")
            {
                Enemy = Instantiate(BasicCentrist, new Vector3(99, 99, 0), new Quaternion(0, 0, 0, 0));         //Position prevents it from spawning in the middle of the screen causing a quick flash.
            }
            else if (centristType == "Radical")
            {
                Enemy = Instantiate(RadicalCentrist, new Vector3(99, 99, 0), new Quaternion(0, 0, 0, 0));
            }
            else if (centristType == "Anti")
            {
                Enemy = Instantiate(AntiExtremist, new Vector3(99, 99, 0), new Quaternion(0, 0, 0, 0));
            }
            else
            {
                Enemy = Instantiate(HorseshoeCentrist, new Vector3(99, 99, 0), new Quaternion(0, 0, 0, 0));
            }
            Centrist cScript = Enemy.GetComponent<Centrist>();
            if (spacing == "Close")
            {
                cScript.distance = ((float)i / 5 -(float)4) * -1;
            }
            else if (spacing == "Medium")
            {
                cScript.distance = ((float)i / 2 - (float)4) * -1;
            }
            else
            {
                cScript.distance = ((float)i - (float)4) * -1;
            }
            enemyMax += 1;
        }
        if (last)
        {
            allReleased = true;
        }
        yield break; //Ends coroutine
    }

    IEnumerator SendWaves()
    {
        WaveOne();
        yield return new WaitUntil(() => nextWave);
        WaveTwo();
        yield return new WaitUntil(() => nextWave);
        WaveThree();
        yield return new WaitUntil(() => nextWave);
        WaveFour();
        yield return new WaitUntil(() => nextWave);
        WaveFive();
        yield return new WaitUntil(() => nextWave);
        WaveSix();
        yield return new WaitUntil(() => nextWave);
        WaveSeven();
        yield return new WaitUntil(() => nextWave);
        WaveEight();
        yield return new WaitUntil(() => nextWave);
        WaveNine();
        yield return new WaitUntil(() => nextWave);
        WaveTen();
        yield return new WaitUntil(() => nextWave);
        SceneManager.LoadScene(2);
    }

    private void EndWave() 
    {
        waveNo += 1;
        GlobalVars.cash += 10 * waveNo;
        enemyMax = 0;
        enemyKilled = 0;
        waveText.text = "Wave: " + (waveNo + 1).ToString();
        allReleased = false;
        nextWave = true;
    }

    private void WaveOne()
    {
        GlobalVars.EnemyHealthPercent = 100;
        nextWave = true;
        StartCoroutine(SpawnWaves("Basic", 5, "Far", 3, true));        //Put, in this order: (Enemy Type, number of enemies, distance apart, time until it should send, wether it is the end or not)
        nextWave = false;
        Debug.Log("Wave One");
    }
    
    private void WaveTwo()
    {
        GlobalVars.EnemyHealthPercent = 120;
        StartCoroutine(SpawnWaves("Basic", 6, "Far", 3, false));
        StartCoroutine(SpawnWaves("Basic", 3, "Medium", 6, true));
        nextWave = false;
    }

    private void WaveThree()
    {
        GlobalVars.EnemyHealthPercent = 140;
        StartCoroutine(SpawnWaves("Basic", 6, "Medium", 3, false));
        StartCoroutine(SpawnWaves("Basic", 6, "Medium", 7, false));
        StartCoroutine(SpawnWaves("Basic", 6, "Medium", 11, true));
        nextWave = false;
    }

    private void WaveFour()
    {
        GlobalVars.EnemyHealthPercent = 160;
        StartCoroutine(SpawnWaves("Basic", 18, "Close", 3, true));  
        nextWave = false;
    }

    private void WaveFive()
    {
        GlobalVars.EnemyHealthPercent = 200;                             //Every five waves, the amount of health that goes up per round is increased by double.
        StartCoroutine(SpawnWaves("Basic", 18, "Close", 3, false));
        StartCoroutine(SpawnWaves("Basic", 24, "Medium", 6, true));
        nextWave = false;
    }

    private void WaveSix()
    {
        GlobalVars.EnemyHealthPercent = 240;
        StartCoroutine(SpawnWaves("Basic", 30, "Far", 3, true));
        nextWave = false;
    }

    private void WaveSeven()
    {
        GlobalVars.EnemyHealthPercent = 280;
        StartCoroutine(SpawnWaves("Basic", 8, "Close", 3, false));
        StartCoroutine(SpawnWaves("Basic", 8, "Close", 6, false));
        StartCoroutine(SpawnWaves("Basic", 8, "Close", 9, false));
        StartCoroutine(SpawnWaves("Basic", 8, "Close", 12, false));
        StartCoroutine(SpawnWaves("Basic", 8, "Close", 15, true));
        nextWave = false;
    }
    private void WaveEight()
    {
        GlobalVars.EnemyHealthPercent = 320;
        StartCoroutine(SpawnWaves("Basic", 10, "Close", 3, false));
        StartCoroutine(SpawnWaves("Basic", 10, "Close", 6, false));
        StartCoroutine(SpawnWaves("Basic", 10, "Close", 9, false));
        StartCoroutine(SpawnWaves("Basic", 10, "Close", 12, false));
        StartCoroutine(SpawnWaves("Basic", 10, "Close", 15, true));
        nextWave = false;
    }
    private void WaveNine()
    {
        GlobalVars.EnemyHealthPercent = 360;
        StartCoroutine(SpawnWaves("Basic", 40, "Close", 3, true));
        nextWave = false;
    }

    private void WaveTen()
    {
        GlobalVars.EnemyHealthPercent = 440;
        StartCoroutine(SpawnWaves("Basic", 70, "Medium", 3, true));
        nextWave = false;
    }
}
