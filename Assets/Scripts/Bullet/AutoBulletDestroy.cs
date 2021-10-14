using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBulletDestroy : MonoBehaviour
{
    // Calling variables
    public float destroyTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Telling when the bullet is destroyed
        Destroy(gameObject, destroyTime);
    }
}
