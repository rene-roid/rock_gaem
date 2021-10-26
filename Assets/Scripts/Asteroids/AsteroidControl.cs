using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControl : MonoBehaviour
{
    // xSpeed & ySpeed Variables
    public float xSpeed = 1.0f;
    public float ySpeed = 1.0f;
    public float speed = 1.0f;
    public bool randomSpeed;

    // Calling Asteroid folllow Variables
    public GameObject player; // Getting player pos
    private Vector2 movement;
    private Transform target;
    private Transform antiBreak;

    // Creating xPos & yPos Private Variables
    private float xPos, yPos;

    // MapLimit Variables
    public float xMapLimit, yMapLimit;

    // Bounce Mode or Teleport Mode variables
    public int asteroidMode;


    // Start is called before the first frame update
    void Start()
    {

        if (randomSpeed)
        {
            xSpeed = Random.Range(-xSpeed, xSpeed);
            ySpeed = Random.Range(-ySpeed, ySpeed);
            speed = Random.Range(0, speed);
        }
        // Setting initial possition of xPos & yPos
        xPos = transform.position.x;
        yPos = transform.position.y;

        player = GameObject.FindWithTag("Player");
        if (player)
        {
            target = player.transform;
            antiBreak = player.transform;
        }


    }

    // Update is called once per frame
    void Update()
    {

        // Toggle asteroid mode
        if (asteroidMode == 1 )
        {
            // Moving the asteroid
            xPos += xSpeed * Time.deltaTime; // xPos = xPos + xSpeed * Time.deltaTime;
            yPos += ySpeed * Time.deltaTime; // yPos = yPos + ySpeed * Time.deltaTime
            limitsControl();

            // Move the asteroid to a position
            transform.position = new Vector3(xPos, yPos, 0.0f);
        } else if (asteroidMode == 2)
        {
            // Moving the asteroid
            xPos += xSpeed * Time.deltaTime; // xPos = xPos + xSpeed * Time.deltaTime;
            yPos += ySpeed * Time.deltaTime; // yPos = yPos + ySpeed * Time.deltaTime
            asteroidBounce();

            // Move the asteroid to a position
            transform.position = new Vector3(xPos, yPos, 0.0f);
        } else
        {
            asteroidFollow();
        }

    }

    public float xAsteroidMapBouce, yAsteroidMapBounce;

    void asteroidBounce()
    {
        //Boucing xPos when reaching map limit
        if (xPos > xAsteroidMapBouce && xSpeed > 0)
        {
            xSpeed = -xSpeed;
            new WaitForEndOfFrame();
        }
        else if (xPos < -xAsteroidMapBouce && xSpeed < 0)
        {
            xSpeed = -xSpeed;
            new WaitForEndOfFrame();
        }

        // Bouncing yPos when reaching map limt
        if (yPos > yAsteroidMapBounce && ySpeed > 0)
        {
            ySpeed = -ySpeed;
            new WaitForEndOfFrame();
        }
        else if (yPos < -yAsteroidMapBounce && ySpeed < 0)
        {
            ySpeed = -ySpeed;
            new WaitForEndOfFrame();
        }
    }

    void asteroidBouncev2() //Diff Version of asteroid bounce
    {
        if (xPos > xAsteroidMapBouce) xSpeed = -Mathf.Abs(xSpeed);
        else if (xPos < -xAsteroidMapBouce) xSpeed = Mathf.Abs(xSpeed);

        if (yPos > yAsteroidMapBounce) ySpeed = -Mathf.Abs(ySpeed);
        else if (yPos < -yAsteroidMapBounce) ySpeed = Mathf.Abs(ySpeed);
    }

    void limitsControl()
    {
        //Moving xPos when reaching map limit
        if (xPos > xMapLimit)
        {
            xPos = -xMapLimit;
        }
        else if (xPos < -xMapLimit)
        {
            xPos = xMapLimit;
        }

        // Moving yPos when reaching map limt
        if (yPos > yMapLimit)
        {
            yPos = -yMapLimit;
        }
        else if (yPos < -yMapLimit)
        {
            yPos = yMapLimit;
        }
    }

    void asteroidFollow()
    {
        if (player)
        {
            // Getting distance between asteroid and player
            Vector2 direction = target.position - transform.position;
            direction.Normalize();
            movement = direction;
        } else
        {
            // Getting distance between asteroid and player
            Vector2 direction = antiBreak.position;
            direction.Normalize();
            movement = direction;
        }

        // Moving asteroid
        transform.position = (Vector2)transform.position + (movement * speed * Time.deltaTime);
    }

    public GameObject explosionEffect, asteroidMid, asteroidSmol;
    public int asteroidLife;
    public static bool asteroidDestroyed = false, asteroidHit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            asteroidLife --;
            asteroidHit = true;
        }

        asteroidDieControl();

        if (collision.tag == "Player" && Time.time > PlayerHP.nextShieldAsteroid)
        {
            asteroidDestroyed = true;
            GameObject explosionEffectCopy = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosionEffectCopy, 2);
            if (gameObject.name == "AsteroidTeleport" || gameObject.name == "AsteroidTeleport(Clone)" || gameObject.name == "AsteroidBounce" || gameObject.name == "AsteroidBounce(Clone)" || gameObject.name == "AsteroidFollow" || gameObject.name == "AsteroidFollow(Clone)")
            {
                Score.score += 69 * 3;
                BigExplosion();
            }
            else if (gameObject.name == "MediumAsteroidTeleport" || gameObject.name == "MediumAsteroidTeleport(Clone)" || gameObject.name == "MediumAsteroidBounce" || gameObject.name == "MediumAsteroidBounce(Clone)" || gameObject.name == "MediumAsteroidFollow" || gameObject.name == "MediumAsteroidFollow(Clone)")
            {
                Score.score += 69 * 2;
                MidExplosion();
            }
            else if (gameObject.name == "SmolAsteroidTeleport" || gameObject.name == "SmolAsteroidTeleport(Clone)" || gameObject.name == "SmolAsteroidBounce" || gameObject.name == "SmolAsteroidBounce(Clone)" || gameObject.name == "SmolAsteroidFollow" || gameObject.name == "SmolAsteroidFollow(Clone)")
            {
                Score.score += 69;
            }

            PlayerHP.nextShieldAsteroid = Time.time + PlayerHP.shieldCDAsteroid;
        }
    }

    private void BigExplosion()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject asteroidMidCopy = Instantiate(asteroidMid, transform.position, transform.rotation);
        }
    }
    private void MidExplosion()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject asteroidSmolCopy = Instantiate(asteroidSmol, transform.position, transform.rotation);
        }
    }

    private void asteroidDieControl()
    {
        if (asteroidLife <= 0)
        {
            asteroidDestroyed = true;
            GameObject explosionEffectCopy = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosionEffectCopy, 2);

            if (gameObject.name == "AsteroidTeleport" || gameObject.name == "AsteroidTeleport(Clone)" || gameObject.name == "AsteroidBounce" || gameObject.name == "AsteroidBounce(Clone)" || gameObject.name == "AsteroidFollow" || gameObject.name == "AsteroidFollow(Clone)")
            {
                BigExplosion();
            }
            else if (gameObject.name == "MediumAsteroidTeleport" || gameObject.name == "MediumAsteroidTeleport(Clone)" || gameObject.name == "MediumAsteroidBounce" || gameObject.name == "MediumAsteroidBounce(Clone)" || gameObject.name == "MediumAsteroidFollow" || gameObject.name == "MediumAsteroidFollow(Clone)")
            {
                MidExplosion();
            }
        }
    }
}