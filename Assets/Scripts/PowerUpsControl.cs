using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsControl : MonoBehaviour
{
    public GameObject pSystem;
    public static bool bulletPowerUpUnlocked = false;

    private int wave;

    // Start is called before the first frame update
    void Start()
    {
        bulletPowerUpUnlocked = false;
        BulletModeControl.powerUpBulletMode = 0;
    }

    // Update is called once per frame
    void Update()
    {
        wave = WaveSpawner.nextWaveUI -1;

        switch (wave)
        {
            case 0:
                BulletModeControl.powerUpBulletMode = 0;
                break;
            case 1:
                BulletModeControl.powerUpBulletMode = 2;
                break;
            case 2:
                BulletModeControl.powerUpBulletMode = 3;
                break;
            case 3:
                BulletModeControl.powerUpBulletMode = 4;
                break;
            case 4:
                BulletModeControl.powerUpBulletMode = 5;
                break;
            case 5:
                BulletModeControl.powerUpBulletMode = 6;
                break;
            case 6:
                BulletModeControl.powerUpBulletMode = 6;
                break;
            default:
                BulletModeControl.powerUpBulletMode = 6;
                break;

        }

        if (Score.score >= 12000) {
            bulletPowerUpUnlocked = true;
        }
    }
}
