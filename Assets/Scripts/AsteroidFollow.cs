using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    private Rigidbody2D rigid2dBody;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rigid2dBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rigid2dBody.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}