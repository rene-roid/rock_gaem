using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public enum spawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemy;
        public int enemyCount;
        public float spawnEnemyRate;
    }

    public Wave[] waves;
    private int nextWave = 0, nextWaveUI = 1;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5.0f;
    public float waveCountDown = 0.0f;

    private float searchCountDown = 1f;

    public spawnState state = spawnState.COUNTING;

    public Text waveCompletedUI;
    public GameObject waveCompletedGM;

    // Start is called before the first frame update
    void Start()
    {
        waveCountDown = timeBetweenWaves;

        if (spawnPoints.Length == 0)
        {
            Debug.Log("No spawnpoints");
        }

        waveCompletedGM.SetActive(true);
        waveCompletedUI.text = "Wave " + nextWaveUI;

    }

    // Update is called once per frame
    void Update()
    {

        if (state == spawnState.WAITING)
        {
            if (!enemyIsAlive())
            {
                waveCompleted();
            } else
            {
                return;
            }
        }

        if (waveCountDown <= 0)
        {
            if (state != spawnState.SPAWNING)
            {
                waveCompletedGM.SetActive(false);
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        } else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    void waveCompleted()
    {
        Debug.Log("Wave Completed");

        state = spawnState.COUNTING;
        waveCountDown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length -1)
        {
            for (int j = 0; j < waves.Length -1; j++)
            {
                waves[j].enemyCount++;
            }
            nextWave = 0;
            Debug.Log("You won");
            waveCompletedVoidUI();
            return;
        } else
        {
            nextWave++;
            waveCompletedVoidUI();
        }

    }

    void waveCompletedVoidUI()
    {
        nextWaveUI++;
        waveCompletedGM.SetActive(true);
        waveCompletedUI.text = "Wave " + nextWaveUI;
    }

    bool enemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;

        if (searchCountDown <= 0.0f) {

            searchCountDown = 1.0f;
            if (GameObject.FindGameObjectWithTag("Asteroid") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("spawingWave");
        state = spawnState.SPAWNING;

        for (int i = 0; i <_wave.enemyCount; i++)
        {
            SpawnEnemy(_wave.enemy[Random.Range(0, _wave.enemy.Length)]);
            yield return new WaitForSeconds(1f / _wave.spawnEnemyRate);
        }


        state = spawnState.WAITING;

        yield break;
    }

    void SpawnEnemy (Transform _enemy)
    {
        print("spawning");

        Transform _spawnPoints = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(_enemy, _spawnPoints.position, _spawnPoints.rotation);
    }
}
