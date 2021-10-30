using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathVars : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BulletModeControl.powerUpBulletMode = 0;
        PowerUpsControl.bulletPowerUpUnlocked = false;
        WaveSpawner.nextWaveUI = 1;

        PlayerHP.ded = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
