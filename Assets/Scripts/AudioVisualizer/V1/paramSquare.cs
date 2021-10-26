using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paramSquare : MonoBehaviour
{
    public int _band;
    public float _startScale, _scaleMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector2(1, (AudioSpectrumControl._freqBand[_band] * _scaleMultiplier) + _startScale);
    }
}
