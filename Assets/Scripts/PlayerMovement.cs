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

    public float dashDistance, dashCooldown;
    private float nextDash, bruhDashParticle, bruhNextDash;
    public ParticleSystem playerFart;
    public ParticleSystem dashParticle;
    private AudioSource AudioDash;

    // Start is called before the first frame update
    void Start()
    {
        playerRot = transform.eulerAngles.z;
        AudioDash = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the player
        playerRot -= rotSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;

        // Quaternion with anglesnot verctor 3
        transform.rotation = Quaternion.Euler(0f, 0f, playerRot);

        dash();
        // Move the player
        transform.position += transform.up * Input.GetAxis("Vertical") * ySpeed * Time.deltaTime;
        CreateParticles();

        limitsControl();
        
    }
    void limitsControl()
    {
        xPos = transform.position.x;
        yPos = transform.position.y;

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
        playerFart.Play();
 
    }

    void dash()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true) {
            if (Time.time > nextDash)
            {
                dashParticle.Play();
                new WaitForEndOfFrame();
                AudioDash.Play();
                transform.position += transform.up * (dashDistance * 100) * Time.deltaTime;
                nextDash = Time.time + dashCooldown;

            }
        }
    }
}
