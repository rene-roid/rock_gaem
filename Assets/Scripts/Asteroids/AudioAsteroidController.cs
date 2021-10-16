using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAsteroidController : MonoBehaviour
{
    public AudioClip[] sfx;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AsteroidControl.asteroidDestroyed)
        {
            AsteroidControl.asteroidHit = false;
            audioSource.clip = sfx[1];
            audioSource.Play();
            print("a");
            AsteroidControl.asteroidDestroyed = false;
        } else if (AsteroidControl.asteroidHit)
        {
            audioSource.clip = sfx[0];
            audioSource.Play();
            print("b");
            AsteroidControl.asteroidHit = false;
        }
    }
}
