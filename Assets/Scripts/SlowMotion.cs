using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public float slowmoCD, slowmoDuration;
    private float slowmo, nextSlowmo;
    public static bool isSlowmo = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && Time.time > nextSlowmo && PauseMenu.gameIsPaused == false)
        {
            isSlowmo = true;
            Time.timeScale = 0.2f;
            slowmo = Time.time + slowmoDuration * 0.2f;
            nextSlowmo = Time.time + slowmoCD + slowmoDuration * 0.2f;

        }

        if (Time.time > slowmo && PauseMenu.gameIsPaused == false)
        {
            isSlowmo = false;
            Time.timeScale = 1.0f;
        }
    }
}
