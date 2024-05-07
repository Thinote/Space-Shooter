using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField] public Vector2 Direction;
    [SerializeField] float speed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 5 || transform.position.y < -5 || transform.position.x > 5 || transform.position.x < -5)
        {
            Destroy(gameObject);
        }
    
    }

    private void FixedUpdate()
    {
        rb.velocity = Direction.normalized * speed;
    }

    public void Impact()
    {
        Destroy(gameObject);
    }
}
