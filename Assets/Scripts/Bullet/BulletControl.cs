using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    // Calling variables
    public float bulletSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Moving the bullet upwards
        transform.position += transform.up * bulletSpeed * Time.deltaTime;
    }

}
