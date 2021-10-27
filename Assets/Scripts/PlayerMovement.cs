using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Variables
    public float rotSpeed = 180.0f, ySpeed = 1.0f;
    private float playerRot;

    // Map Control Variables
    public float xMapLimit, yMapLimit;
    private float xPos, yPos;

    // Dash Variables
    public float dashDistance, dashCooldown;
    public static float dashCD;
    private float nextDash;
    public GameObject fartParticle;
    public ParticleSystem playerFart;
    public ParticleSystem dashParticle;
    private AudioSource AudioDash;
    private bool dashActive;

    // Start is called before the first frame update
    void Start()
    {
        playerFart.Stop();
        // Dash Cooldown
        dashCD = dashCooldown;

        // Setting player rotation
        playerRot = transform.eulerAngles.z;

        // Dash audio
        AudioDash = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calling slowmotion velocity
        slowmoVel();

        // Rotate the player
        playerRot -= rotSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;

        // Quaternion with anglesnot verctor 3
        transform.rotation = Quaternion.Euler(0f, 0f, playerRot);

        // Calling dash
        dash();

        CreateParticles();

        // Move the player
        transform.position += transform.up * Input.GetAxis("Vertical") * ySpeed * Time.deltaTime;

        // Limits control mode
        limitsControl();

        if (PlayerHP.ded)
        {
            ySpeed = 0f;
        }

    }
    void limitsControl()
    {

        // Getting player pos
        xPos = transform.position.x;
        yPos = transform.position.y;

        // If player reaches map limit tp on the oposite side
        if (xPos > xMapLimit) xPos = -xMapLimit;
        else if (xPos < -xMapLimit) xPos = xMapLimit;
        if (yPos > yMapLimit) yPos = -yMapLimit;
        else if (yPos < -yMapLimit) yPos = yMapLimit;

        transform.position = new Vector3(xPos, yPos, 0.0f);

        /* Moving xPos when reaching map limit
        if (xPos > xMapLimit)
        {
            print("xMapLimit Reached");
            transform.position = new Vector3(-xMapLimit, 0.0f, 0.0f);
        }
        else if (xPos < -xMapLimit)
        {
            print("-xMapLimit Reached");
            transform.position = new Vector3(xMapLimit, 0.0f, 0.0f);
        }

        // Moving yPos when reaching map limt
        if (yPos > yMapLimit)
        {
            print("yMapLimit Reached");
            yPos = -yMapLimit;
        }
        else if (yPos < -yMapLimit)
        {
            print("-yMapLimit Reached");
            yPos = yMapLimit;
        }
        */
    }


    void CreateParticles()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerFart.Play();
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            playerFart.Stop();
        }

    }

    void dash()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKey("joystick button 6"))
        {
            // Viewing dash is in cooldown
            if (dashActive == false && Time.time > nextDash)
            {
                // Playing particle system
                dashParticle.Play();
                dashActive = true;

                // Adding small delay for particle system and calling setDash()
                Invoke("setDash", 0.05f);

                // Setting cooldown
                nextDash = Time.time + dashCD;

            }
        }
    }

    void setDash()
    {
        // Teleporting the player
        transform.position += transform.up * (dashDistance * 100) * Time.deltaTime;

        // Playing dash sfx
        AudioDash.Play();

        // Naa dash is no longer active ;(
        dashActive = false;
    }

    void slowmoVel()
    {
        // If is in slowmo make the ship faster and rotate faster
        if (SlowMotion.isSlowmo)
        {
            ySpeed = 14;
            rotSpeed = 720;

        } else
        {
            ySpeed = 7;
            rotSpeed = 240;
        }
    }
}
