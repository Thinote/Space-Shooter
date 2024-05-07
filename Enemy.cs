using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool isVisible = false;
    [SerializeField] int life = 2;
    bool isFlashing = false;
    [SerializeField] Vector2 speed;
    Rigidbody2D rb;
    [SerializeField] Transform frontCanon;
    [SerializeField] GameObject ProjectilePrefab;
    [SerializeField] float delayFirstShoot = 1f;
    [SerializeField] float delayNextShoot = 1f;
    [SerializeField] GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlashing)
        {
            GetComponent<SpriteRenderer>().color = Color.Lerp(
                GetComponent<SpriteRenderer>().color,
                Color.white,
                0.1f);
            if(GetComponent<SpriteRenderer>().color == Color.white)
            {
                isFlashing = false;
            }
        }
        if(transform.position.y <5 && isVisible == false)
        {
            isVisible = true;
            SendMessage("OnVisible", SendMessageOptions.DontRequireReceiver);   
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = speed;    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ProjectilePlayer"))
        {
            Flash();
            life--;
            collision.GetComponent<Projectiles>().Impact();
            if (life <= 0)
            {
                Explode();
            }
        }
    }

    void Flash()
    {
        isFlashing = true;
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void ShootToDirection(float DirectionX, float DirectionY)
    {
        Vector2 direction = new Vector2(DirectionX, DirectionY);
        GameObject p = Instantiate(ProjectilePrefab);
        p.transform.position = frontCanon.position;
        p.GetComponent<Projectiles>().Direction = direction;
    }

    public void Explode()
    {
        GameObject e = Instantiate(explosionPrefab);
        e.transform.position = transform.position;

        SendMessage("OnExplode", SendMessageOptions.DontRequireReceiver);

        Destroy(gameObject);
    }

    public void StartAttacking()
    {
        InvokeRepeating("Shoot", delayFirstShoot, delayNextShoot);
    }

    void Shoot()
    {
        SendMessage("OnShoot", SendMessageOptions.DontRequireReceiver);
    }
}
