using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControl : MonoBehaviour
{
    // xSpeed & ySpeed Variables
    public float xSpeed = 1.0f;
    public float ySpeed = 1.0f;

    // Creating xPos & yPos Private Variables
    private float xPos, yPos;

    // MapLimit Variables
    public float xMapLimit, yMapLimit;

    // Bounce Mode or Teleport Mode variables
    public bool asteroidMode;

    // Start is called before the first frame update
    void Start()
    {
        // Setting initial possition of xPos & yPos
        xPos = transform.position.x;
        yPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Moving the asteroid
        xPos += xSpeed * Time.deltaTime; // xPos = xPos + xSpeed * Time.deltaTime;
        yPos += ySpeed * Time.deltaTime; // yPos = yPos + ySpeed * Time.deltaTime

        // Toggle asteroid mode
        if (asteroidMode == true )
        {
            limitsControl();
        } else
        {
            asteroidBounce();
        }

        // Move the asteroid to a position
        transform.position = new Vector3(xPos, yPos, 0.0f);

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

    void asteroidBouncev2()
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
}