using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OLDAsteroidFollow : MonoBehaviour
{
    // Calling Variables
    public Transform player; // Getting player pos
    public float speed = 5f;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Getting distance between asteroid and player
        Vector2 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
        // Moving asteroid
        transform.position = (Vector2)transform.position + (movement * speed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        
        // transform.position = (Vector2)transform.position + (movement * speed * Time.deltaTime);
    }
}