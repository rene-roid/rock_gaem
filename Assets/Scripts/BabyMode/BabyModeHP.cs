using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BabyModeHP : MonoBehaviour
{
    private int health = 1000000;

    public static float nextShield, nextShieldAsteroid;
    public static float shieldCD = 2, shieldCDAsteroid = 2;

    // Healing vars
    private float healCD = 0.05f;
    private float nextHeal;
    private bool damageTaken = false;

    // Shield effect
    private SpriteRenderer spriteRenderer;
    private Color endColor = Color.cyan;
    private Color startColor;
    private float duration = 1f;

    // Ded
    public static bool ded = false;
    public ParticleSystem dedExplosion;
    public GameObject dedUI;

    // BabyModeUI
    public Text babyHPText;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
        babyHPText.text = "HP: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        healing();
        shieldEffect();

        babyHPText.text = "HP: " + health;
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
            dedExplosion.Play();
            dedUI.SetActive(true);
            ded = true;
            print("game over");
            Destroy(gameObject);
        }
    }

    void healing()
    {
        // if the time has passed and hasnt taken damage it heals 1 hp
        if (Time.time > nextHeal && damageTaken == false && !ded)
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

    private float elapsedTimeShield = 0;
    private float elapsedTimeNormal = 0;
    void shieldEffect()
    {
        if (Time.time < nextShield)
        {
            elapsedTimeNormal = 0;
            elapsedTimeShield += Time.deltaTime;
            float percentageComplete = elapsedTimeShield / duration;

            spriteRenderer.color = Color.Lerp(startColor, endColor, percentageComplete);
        }
        else if (spriteRenderer.color != startColor)
        {

            elapsedTimeNormal += Time.deltaTime;
            float percentageComplete = elapsedTimeNormal / duration;

            spriteRenderer.color = Color.Lerp(endColor, startColor, percentageComplete);
            //spriteRenderer.color = startColor;
        }

        if (Time.time >= nextShield)
        {
            elapsedTimeShield = 0;
        }
    }
}
