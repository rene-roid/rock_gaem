using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    public enum stateBoss { ATTACKING, WAITING, NORMAL, ENRAGED };
    public stateBoss state = stateBoss.WAITING;
    public stateBoss status = stateBoss.NORMAL;

    public GameObject bossBullet;
    public GameObject[] gun1, gun2, gun3;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0.0f, 4.96f);
        xMaxBoss = 6.8f;
        yMapBoss = 3.12f;
        xBossSpeed = 10f;
        yBossSpeed = -10f;
        xBossPos = transform.position.x;
        yBossPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == stateBoss.WAITING)
        {
            if (status == stateBoss.NORMAL)
            {
                int attack = Random.Range(0, 5);

                switch (attack)
                {
                    case 0:
                        state = stateBoss.ATTACKING;
                        bulletRain();
                        break;
                    case 1:
                        state = stateBoss.ATTACKING;
                        spiralBomb();
                        break;
                    case 2:
                        state = stateBoss.ATTACKING;
                        spiralModeSwitch();
                        break;
                    case 3:
                        state = stateBoss.ATTACKING;
                        spiralMode();
                        break;
                    case 4:
                        state = stateBoss.ATTACKING;
                        bouncyBoss();
                        break;
                }
            }

        }

        //bulletRain();
        //spiralBomb();
        //spiralModeSwitch();
        //spiralMode();
        //bouncyBoss();
    }

    // bullet rain
    void bulletRain()
    {

         StartCoroutine(SpawnWave(bossBullet));

    }
    IEnumerator SpawnWave(GameObject _bullet)
    {

        for (int i = 0; i < 100; i++)
        {
            bulletRainSpawner(_bullet);

            yield return new WaitForSeconds(0.025f);
        }
        yield return state = stateBoss.WAITING;
    }

    void bulletRainSpawner(GameObject _bulletIns)
    {
        Instantiate(_bulletIns, new Vector2(Random.Range(-8.9f, 8.9f), 5.8f), Quaternion.Euler(0f, 0f, -90f));
    }

    // bullet spiral bomb
    void spiralBomb()
    {
        StartCoroutine(spawnBomb(bossBullet));
        
    }

    IEnumerator spawnBomb(GameObject _bullet)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < gun1.Length; j++)
            {
                Instantiate(_bullet, gun1[j].transform.position, gun1[j].transform.rotation);
            }
            for (int k = 0; k < gun2.Length; k++)
            {
                Instantiate(_bullet, gun2[k].transform.position, gun2[k].transform.rotation);
            }            
            for (int q = 0; q < gun2.Length; q++)
            {
                Instantiate(_bullet, gun3[q].transform.position, gun3[q].transform.rotation);
            }

            yield return new WaitForSeconds(0.2f);
        }

        yield return state = stateBoss.WAITING;
    }

    // bullet spiral switch
    void spiralModeSwitch()
    {

         StartCoroutine(spawnSpritalSwitch(bossBullet));
    }

    IEnumerator spawnSpritalSwitch(GameObject _bullet)
    {
        for (int i = 0; i < 1; i++)
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
            for (int q = 0; q < gun2.Length; q++)
            {
                Instantiate(_bullet, gun3[q].transform.position, gun3[q].transform.rotation);
                yield return new WaitForSeconds(0.1f);
            }

            //yield return new WaitForSeconds(0.2f);
        }

        yield return state = stateBoss.WAITING;
    }

    // bullet spiral
    void spiralMode()
    {
         StartCoroutine(spawnSprital(bossBullet));
    }

    IEnumerator spawnSprital(GameObject _bullet)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < gun1.Length; k++)
            {
                Instantiate(_bullet, gun1[k].transform.position, gun1[k].transform.rotation);
                Instantiate(_bullet, gun2[k].transform.position, gun2[k].transform.rotation);
                Instantiate(_bullet, gun3[k].transform.position, gun3[k].transform.rotation);
                yield return new WaitForSeconds(0.05f);
            }
            for (int j = gun1.Length; j-- > 0;)
            {
                Instantiate(_bullet, gun1[j].transform.position, gun1[j].transform.rotation);
                Instantiate(_bullet, gun2[j].transform.position, gun2[j].transform.rotation);
                Instantiate(_bullet, gun3[j].transform.position, gun3[j].transform.rotation);
                yield return new WaitForSeconds(0.05f);
            }
        }

        yield return state = stateBoss.WAITING;
    }

    // Bouncy boss
    private float xMaxBoss, yMapBoss, xBossSpeed, yBossSpeed, xBossPos, yBossPos;

    void bouncyBoss()
    {
        StartCoroutine(bouncyBossEnum());
    }

    IEnumerator bouncyBossEnum()
    {

        float timePassed = 0;
        float time = 6;
        xBossPos = transform.position.x;
        yBossPos = transform.position.y;

        while (timePassed < time)
        {
            // Moving the asteroid
            xBossPos += xBossSpeed * Time.deltaTime; // xPos = xPos + xSpeed * Time.deltaTime;
            yBossPos += yBossSpeed * Time.deltaTime; // yPos = yPos + ySpeed * Time.deltaTime

            //Boucing xPos when reaching map limit
            if (xBossPos > xMaxBoss && xBossSpeed > 0)
            {
                xBossSpeed = -xBossSpeed;
            }
            else if (xBossPos < -xMaxBoss && xBossSpeed < 0)
            {
                xBossSpeed = -xBossSpeed;
            }

            // Bouncing yPos when reaching map limt
            if (yBossPos > yMapBoss && yBossSpeed > 0)
            {
                yBossSpeed = -yBossSpeed;
            }
            else if (yBossPos < -yMapBoss && yBossSpeed < 0)
            {
                yBossSpeed = -yBossSpeed;
            }

            // Move the asteroid to a position
            transform.position = new Vector2(xBossPos, yBossPos);

            timePassed += Time.deltaTime;
            yield return null;
        } 

        if (timePassed > time)
        {
            transform.position = new Vector2(0.0f, 4.96f);
        }

        yield return state = stateBoss.WAITING;
    }

    private int BossHP = 300;
    void BossHpControl ()
    {
        if (status == stateBoss.ENRAGED)
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            BossHP--;
            if (BossHP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
