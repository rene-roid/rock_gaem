using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class slowmoPost : MonoBehaviour
{
    private Volume v;
    private ChromaticAberration ChAbrr;

    // Start is called before the first frame update
    void Start()
    {
        v = GetComponent<Volume>();
        v.profile.TryGet(out ChAbrr);
    }

    // Update is called once per frame
    void Update()
    {
        ChAbrr.intensity.value = 1;
    }
}
