using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{
    // Calling variables
    public GameObject bullet;
    public float bulletCooldownTime;
    private float bulletTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Spawning bullet
        if (((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) || Input.GetKey("joystick button 1")) && Time.time > bulletTime) && PauseMenu.gameIsPaused == false)
        {
            // Spawning bullet in the correct dierction
            GameObject bulletCopy = Instantiate(bullet, transform.position, transform.rotation);
            bulletTime = Time.time + bulletCooldownTime; // Firerate cooldown
        }
    }
}
