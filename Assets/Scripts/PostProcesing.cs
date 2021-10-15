using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcesing : MonoBehaviour
{
    PostProcessVolume volume;
    Bloom bloomLayer;
    public static PostProcesing current;

    private void Awake()
    {
        volume = gameObject.GetComponent<PostProcessVolume>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // If there is more than one audio source, destroy it
        if (current) { Destroy(gameObject); } else { current = this; }

        // Dont destroy on load, so music nevers stops
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(SettingsMenu.bloomMode) { volume.enabled = true; } else { volume.enabled = false;  }
    }

}
