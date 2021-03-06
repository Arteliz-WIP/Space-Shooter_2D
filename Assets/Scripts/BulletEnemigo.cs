﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemigo : MonoBehaviour
{
    public float speed = 20f;
    public float damageAmount = 10f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meteorite"))
        {
            Meteorite meteorite = collision.gameObject.GetComponent<Meteorite>();

            if (meteorite != null)
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player != null)
            {
                player.Damage(damageAmount);

                Destroy(this.gameObject);
            }
        }
    }      
}
