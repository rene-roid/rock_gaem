using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public static bool bloomMode = true;

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void setBloomOn(bool bloom)
    {
        bloomMode = true;
    }

    public void setBloomOff(bool bloom)
    {
        bloomMode = false;
    }

}
