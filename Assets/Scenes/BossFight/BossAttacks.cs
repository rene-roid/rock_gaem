using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    public GameObject bossBullet;
    public GameObject[] gun1, gun2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletRain();
        spiralBomb();
        spiralModeSwitch();
        spiralMode();
    }

    // bullet rain
    void bulletRain()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(SpawnWave(bossBullet));
        }
    }
    IEnumerator SpawnWave(GameObject _bullet)
    {

        for (int i = 0; i < 500; i++)
        {
            bulletRainSpawner(_bullet);

            yield return new WaitForSeconds(0.025f);
        }
        yield break;
    }

    void bulletRainSpawner(GameObject _bulletIns)
    {
        Instantiate(_bulletIns, new Vector2(Random.Range(-8.9f, 8.9f), 5.8f), Quaternion.Euler(0f, 0f, -90f));
    }

    // bullet spiral bomb
    void spiralBomb()
    {
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(spawnBomb(bossBullet));
        }
    }

    IEnumerator spawnBomb(GameObject _bullet)
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < gun1.Length; j++)
            {
                Instantiate(bossBullet, gun1[j].transform.position, gun1[j].transform.rotation);
            }
            for (int k = 0; k < gun2.Length; k++)
            {
                Instantiate(bossBullet, gun2[k].transform.position, gun2[k].transform.rotation);
            }

            yield return new WaitForSeconds(0.2f);
        }
    }

    // bullet spiral switch
    void spiralModeSwitch()
    {
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(spawnSpritalSwitch(bossBullet));
        }
    }

    IEnumerator spawnSpritalSwitch(GameObject _bullet)
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < gun1.Length; j++)
            {
                Instantiate(_bullet, gun1[j].transform.position, gun1[j].transform.rotation);
                yield return new WaitForSeconds(0.1f);
            }
            for (int k = 0; k < gun2.Length; k++)
            {
                Instantiate(_bullet, gun2[k].transform.position, gun2[k].transform.rotation);
                yield return new WaitForSeconds(0.1f);
            }

            //yield return new WaitForSeconds(0.2f);
        }
    }

    // bullet spiral
    void spiralMode()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            StartCoroutine(spawnSprital(bossBullet));
        }
    }

    IEnumerator spawnSprital(GameObject _bullet)
    {
        for (int i = 0; i < 10; i++)
        {
            for (int k = 0; k < gun1.Length; k++)
            {
                Instantiate(_bullet, gun1[k].transform.position, gun1[k].transform.rotation);
                Instantiate(_bullet, gun2[k].transform.position, gun2[k].transform.rotation);
                yield return new WaitForSeconds(0.05f);
            }
            for (int j = gun1.Length; j-- > 0;)
            {
                Instantiate(_bullet, gun1[j].transform.position, gun1[j].transform.rotation);
                Instantiate(_bullet, gun2[j].transform.position, gun2[j].transform.rotation);
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
