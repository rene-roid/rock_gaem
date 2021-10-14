using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModeControl : MonoBehaviour
{
    // Calling variables
    public List<GameObject> shots;

    // Update is called once per frame
    void Update()
    {
        // When z/x is pressed the cannon mode changes from 1 to 2 bullets
        if (Input.GetKeyDown(KeyCode.Z))
        {
            print("modo 1 x");
            shots[0].SetActive(true);
            shots[1].SetActive(false);

        } else if (Input.GetKeyDown(KeyCode.X))
        {
            print("modo 2 x");
            shots[0].SetActive(false);
            shots[1].SetActive(true);
        }
    }
}
