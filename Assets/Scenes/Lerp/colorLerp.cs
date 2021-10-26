using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorLerp : MonoBehaviour
{
    SpriteRenderer me;
    private Color endColor = Color.red;
    private Color startColor;
    private float duration = 3f;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        me = GetComponent<SpriteRenderer>();
        startColor = me.color;
    }

    // Update is called once per frame
    void Update()
    {

        if (me.color != endColor)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / duration;

            me.color = Color.Lerp(startColor, endColor, percentageComplete);
        }
    }
}