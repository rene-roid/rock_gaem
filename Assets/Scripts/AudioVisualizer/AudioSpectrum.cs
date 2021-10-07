using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrum : MonoBehaviour
{
    private float[] audioSpetrum;
    public static float spectrumValue { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        audioSpetrum = new float[128];
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.GetSpectrumData(audioSpetrum, 0, FFTWindow.Hamming);

        if (audioSpetrum != null && audioSpetrum.Length > 0) { spectrumValue = audioSpetrum[0] * 100; }
    }
}
