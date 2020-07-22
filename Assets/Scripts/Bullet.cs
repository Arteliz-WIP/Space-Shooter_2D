using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float damageAmount = 10f;

    public GameObject hitparticlePrefab;

    private Rigidbody2D rb;            
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meteorite"))
        {
            Meteorite meteorite = collision.gameObject.GetComponent<Meteorite>();

            if (meteorite != null)
            {
                FindObjectOfType<Score>().AddPoints(5);

                meteorite.DestroyMeteorite();
                Destroy(this.gameObject);
            }
        }

        else if (collision.gameObject.CompareTag("Enemigo"))
        {
            Enemigo enemigo = collision.gameObject.GetComponent<Enemigo>();
            if (enemigo != null)
            {
                FindObjectOfType<Score>().AddPoints(10);
                enemigo.Damage(damageAmount);

                GameObject particles = Instantiate(hitparticlePrefab, transform.position, transform.rotation);
                Destroy(particles, 5f);
                Destroy(this.gameObject);
            }
        }

        
    }
    
}
