using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlayerMovement : MonoBehaviour
{
    // Variables
    private float xSpeed = 7, ySpeed = 7;

    // Map Control Variables
    public float xMapLimit, yMapLimit, negYMapLimit;
    private float xPos, yPos;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move the player
        transform.position += transform.up * Input.GetAxis("Vertical") * ySpeed * Time.deltaTime;
        transform.position += transform.right * Input.GetAxis("Horizontal") * xSpeed * Time.deltaTime;

        // Limits control mode
        limitsControl();

    }
    void limitsControl()
    {

        // Getting player pos
        xPos = transform.position.x;
        yPos = transform.position.y;

        // If player reaches map limit tp on the oposite side
        if (xPos > xMapLimit) xPos = -xMapLimit;
        else if (xPos < -xMapLimit) xPos = xMapLimit;
        if (yPos >= yMapLimit) yPos = yMapLimit;
        else if (yPos <= negYMapLimit) yPos = negYMapLimit;

        transform.position = new Vector3(xPos, yPos, 0.0f);
    }
}
