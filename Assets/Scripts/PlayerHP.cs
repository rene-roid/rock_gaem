using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Image[] healthPoints;
    private int health = 11;

    public static float nextShield, nextShieldAsteroid;
    public static float shieldCD = 2, shieldCDAsteroid = 2;

    // Healing vars
    private int healCD = 10;
    private float nextHeal;
    private bool damageTaken = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 11) { health = 11; }
        healthBar();
        healing();
    }

    void healthBar()
    {
        for (int i = 0; i < healthPoints.Length; i++)
        {
            healthPoints[i].enabled = !DisplayHealthPoints(health, i);
        }
    }

    bool DisplayHealthPoints(float _health, int pointNumber)
    {
        return (pointNumber >= _health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Asteroid" && Time.time > nextShield)
        {
            health--;
            damageTaken = true;
            nextShield = Time.time + shieldCD;
        }
        
        if (health <= 0)
        {
            print("game over");
        }
    }

    void healing()
    {
        // if the time has passed and hasnt taken damage it heals 1 hp
        if (Time.time > nextHeal && damageTaken == false)
        {
            health++;
            nextHeal = Time.time + healCD;
        }

        // if takes damage reset healing time
        if (damageTaken) 
        { 
            nextHeal = Time.time + healCD;
            damageTaken = false;
        }
    }
}
