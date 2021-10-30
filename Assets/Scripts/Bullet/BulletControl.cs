using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    // Calling variables
    public float bulletSpeed = 10.0f;
    private float xPos, yPos, xMapLimit = 9.1f, yMapLimit = 5.2f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Moving the bullet upwards
        transform.position += transform.up * bulletSpeed * Time.deltaTime;

        if (PowerUpsControl.bulletPowerUpUnlocked)
        {
            limitTeleport();
        }
    }

    private void limitTeleport()
    {
        // Getting player pos
        xPos = transform.position.x;
        yPos = transform.position.y;

        // If player reaches map limit tp on the oposite side
        if (xPos > xMapLimit) xPos = -xMapLimit;
        else if (xPos < -xMapLimit) xPos = xMapLimit;
        if (yPos > yMapLimit) yPos = -yMapLimit;
        else if (yPos < -yMapLimit) yPos = yMapLimit;

        transform.position = new Vector3(xPos, yPos, 0.0f);
    }

}
