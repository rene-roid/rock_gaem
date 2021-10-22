using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCast : MonoBehaviour
{
    public Transform firepoint;
    public LineRenderer line;
    public GameObject lineGM;
    private float lineDistance, fireRate, lineActive;

    public static bool asteroidHitRayCast = false;
    public static Collider2D asteroidRaycastCol;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = 0.1f;
        lineActive = 0.1f;
        // linee = linee.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && fireRate <= 0)
        {
            fireRate = 0.2f;
            lineActive = 0.1f;
            lineGM.SetActive(true);
            shoot();

        } else
        {
            fireRate -= Time.deltaTime;
        }

        if (lineActive <= 0)
        {
            lineGM.SetActive(false);
        } else
        {
            lineActive -= Time.deltaTime;
        }

    }
    void shoot()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(firepoint.position, transform.up, 100f);

        lineDistance = firepoint.position.x - hit.point.x;

        if (hit.collider != null && hit.collider.tag == "Asteroid")
        {
            asteroidHitRayCast = hit.collider;
            print("penelope");
            asteroidHitRayCast = true;
            line.SetPosition(1, new Vector2(0, lineDistance));
        } else {
            line.SetPosition(1, new Vector2(0, firepoint.position.x + 100));
        }
    }
}
