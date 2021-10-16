using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{

    // Calling variables
    public float slowmoCD, slowmoDuration;
    private float slowmo, nextSlowmo;
    public static bool isSlowmo = false;
    public static float slowmotionCD;

    // Start is called before the first frame update
    void Start()
    {
        // Setting cooldown + the "time consumed in the slowmo"
        slowmotionCD = slowmoCD + slowmoDuration * 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        // Calling slowmo when it is on cooldown and when the pause menu is closed
        if ((Input.GetKey(KeyCode.E) || Input.GetKey("joystick button 7")) && Time.time > nextSlowmo && PauseMenu.gameIsPaused == false)
        {
            // Changing timescale and adding cooldown
            isSlowmo = true;
            Time.timeScale = 0.2f;

            // Slowmo duration calcs
            slowmo = Time.time + slowmoDuration * 0.2f;

            // Slowmo cd calcs
            nextSlowmo = Time.time + slowmoCD + slowmoDuration * 0.2f;

        }

        if (Time.time > slowmo && PauseMenu.gameIsPaused == false)
        {
            // When the slowmo end reset timescale
            isSlowmo = false;
            Time.timeScale = 1.0f;
        }
    }
}
