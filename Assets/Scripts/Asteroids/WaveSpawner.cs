using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private int nextWave = 0;
    public static int nextWaveUI = 1;
    private int nextWaveUILocal = 1;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5.0f;
    public float waveCountDown = 0.0f;

    private float searchCountDown = 1f;

    public spawnState state = spawnState.COUNTING;

    public Text waveCompletedUI;
    public GameObject waveCompletedGM;

    // Tutorial vars
    Scene scene;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        nextWaveUI = nextWaveUILocal;

        Scene scene = SceneManager.GetActiveScene();

        waveCountDown = timeBetweenWaves;

        if (spawnPoints.Length == 0)
        {
            Debug.Log("No spawnpoints");
        }

        waveCompletedGM.SetActive(true);
        waveCompletedUI.text = "Wave " + nextWaveUILocal;

    }

    // Update is called once per frame
    void Update()
    {

        // Only works on tutorial scene
        nextWaveUI = nextWaveUILocal;
        try
        {
            switch (nextWaveUILocal)
            {
                case 1:
                    text.text = "WASD to move \n SpaceBar or Left Click to shoot";
                    break;
                case 2:
                    text.text = "Press Q to dash \n Press E to activate slowmotion";
                    break;
                case 3:
                    text.text = "Each round you unlock a new weapon (R)";
                    break;
                case 4:
                    text.text = "Press R to change weapon";
                    break;
                case 5:
                    text.text = "Tutorial completed! \n press Esc to pause & go to homepage";
                    break;
                default:
                    text.text = " ";
                    break;
            }
        } catch
        {
            
        }

        if (state == spawnState.WAITING)
        {
            if (!enemyIsAlive() && !PlayerHP.ded)
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
                waves[j].enemyCount++;
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
        nextWaveUILocal++;
        waveCompletedGM.SetActive(true);
        waveCompletedUI.text = "Wave " + nextWaveUILocal;
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
