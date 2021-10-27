using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletModeControl : MonoBehaviour
{
    // Calling variables
    public GameObject[] shots;
    private int a = 0;
    public Text uiText;

    public static int powerUpBulletMode = 0;

    private void Awake()
    {
        powerUpBulletMode = 0;
        uiText.text = shots[0].name;
    }

    // Update is called once per frame
    void Update()
    {
        switchWeapon();
    }

    void multiKeyMode()
    {
        // When z/x is pressed the cannon mode changes from 1 to 2 bullets
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown("joystick button 0"))
        {
            shots[0].SetActive(true);
            shots[1].SetActive(false);
            shots[2].SetActive(false);

        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            shots[0].SetActive(false);
            shots[1].SetActive(true);
            shots[2].SetActive(false);

        }
        else if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown("joystick button 4"))
        {
            shots[0].SetActive(false);
            shots[1].SetActive(false);
            shots[2].SetActive(true);

        }
    }

    void switchWeapon()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            shots[a].SetActive(false);
            a++;
            if (a > powerUpBulletMode)
            {
                a = 0;
            }
            uiText.text = shots[a].name;
            shots[a].SetActive(true);
        }
    }

    void switchWaponUI()
    {

    }

}
