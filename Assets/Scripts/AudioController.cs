using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    // Calling variables
    private AudioSource sound, lowpass;
    string sceneName;
    public static AudioController current;

    // Start is called before the first frame update
    void Awake()
    {
        // Getting audiosource
        sound = GetComponent<AudioSource>();

        // If there is more than one audio source, destroy it
        if (current) { Destroy(gameObject); } else { current = this; }

        // Dont destroy on load 😏, so music nevers stops
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Getting actual scene name
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        // Cool sound effect when it is on mainmenu
        if (PauseMenu.gameIsPaused || SlowMotion.isSlowmo || sceneName == "MainMenu") { GetComponent<AudioLowPassFilter>().cutoffFrequency = 800; }
        else { GetComponent<AudioLowPassFilter>().cutoffFrequency = 5500; }

        // Pausing music if music was paused
        if (MuteControl.musicIsMuted)
        {
            sound.Pause();
        } else if (!MuteControl.musicIsMuted)
        {
            sound.UnPause();
        }

    }
}