using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsControl : MonoBehaviour
{
    public static bool bulletPowerUpUnlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        bulletPowerUpUnlocked = false;
        BulletModeControl.powerUpBulletMode = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.score >= 12000) {
            BulletModeControl.powerUpBulletMode = 2;
            print(3);
        } else if (Score.score >= 6000)
        {
            bulletPowerUpUnlocked = true;
            print(2);
        } else if (Score.score >= 3000)
        {
            BulletModeControl.powerUpBulletMode = 1;
            print(1);
        }
    }
}
