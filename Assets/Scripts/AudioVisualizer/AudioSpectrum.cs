using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrum : MonoBehaviour
{
    AudioSource sourceAudio;
    public float[] spectrumValues = new float[128];

    // Start is called before the first frame update
    void Start()
    {
        sourceAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
    }

    void GetSpectrumAudioSource()
    {
        sourceAudio.GetSpectrumData(spectrumValues, 0, FFTWindow.Hamming);
    }
}
