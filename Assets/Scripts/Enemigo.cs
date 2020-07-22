using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float MaxHP = 30f;
    public float timeBetweenShoots = 1f;
    public float speed = 5f;

    public GameObject bulletPrefab;
    public Transform bulletOrigin;
    public GameObject EnemydeadParticlePrefab;

    private float currentHP;
    private float timeOfLastShoot;

    private Rigidbody2D rb;

    private void Start()
    {           
       currentHP = MaxHP;        
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
    }

    private void Update()
    {
        
            if (Time.time > timeOfLastShoot + timeBetweenShoots)
                Shoot();      
    }

    public void Damage(float amount)
    {
        currentHP -= amount;

        if (currentHP <= 0f)
        {
            Instantiate(EnemydeadParticlePrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);
        timeOfLastShoot = Time.time;
    }

}
