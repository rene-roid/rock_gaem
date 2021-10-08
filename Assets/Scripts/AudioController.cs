using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource sound, lowpass;

    // Start is called before the first frame update
    void Awake()
    {
        sound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        // Cool sound effect
        if (PauseMenu.gameIsPaused || SlowMotion.isSlowmo ) { GetComponent<AudioLowPassFilter>().cutoffFrequency = 800; }
        else { GetComponent<AudioLowPassFilter>().cutoffFrequency = 5500; }

        if (MuteControl.musicIsMuted)
        {
            sound.Pause();
        } else if (!MuteControl.musicIsMuted)
        {
            sound.UnPause();
        }

    }
}
