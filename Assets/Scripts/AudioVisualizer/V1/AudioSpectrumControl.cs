using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrumControl : MonoBehaviour
{
    AudioSource audioSource;
    public static float[] spectrumSamples = new float[256];
    public static float[] _freqBand = new float[7];
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFreqBands();
    }

    void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(spectrumSamples, 0, FFTWindow.Hamming);
    }

    void MakeFreqBands()
    {
        int count = 0;

        for (int i = 0; i < 7; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            for (int j = 0; j < sampleCount; j++)
            {
                average += spectrumSamples[count] * (count + 1);
                    count++;
            }
            average /= count;

            _freqBand[i] = average * 10;
        }
    }
}
