using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncer : MonoBehaviour
{

    public float bias;
    public float timeStep;
    public float timeToBeat;
    public float restSmoothTime;

    private float previousAudioValue;
    private float audioValue;
    private float timer;

    protected bool isBeat;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // update audio value
        previousAudioValue = audioValue;
        audioValue = AudioSpectrum.spectrumValue;

        // if audio value went below the bias during this frame
        if (previousAudioValue > bias && audioValue <= bias) {
            if (timer > timeStep) { OnBeat(); } 
        }

        // if audio value went above the bias during this frame
        if (previousAudioValue <= bias && audioValue > bias)
        { 
            if (timer > timeStep) { OnBeat(); } 
        }

        timer += Time.deltaTime;
    }

    public virtual void OnBeat()
    {
        timer = 0;
        isBeat = true;
    }

}
