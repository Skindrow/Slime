using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float side;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        if (transform.position.x < 0)
            side = 1;
        else if (transform.position.x > 0)
            side = -1;
    }
    
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(HorizontalProjectileSpawner.shootSpeed * side, 0);
    }
    private void Update()
    {
        if (side == 1 && transform.position.x > 18.0f)
            Destroy(gameObject);
        if (side == -1 && transform.position.x < -18.0f)
            Destroy(gameObject);
    }
}
