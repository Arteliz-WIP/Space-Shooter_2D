using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;

    private Rigidbody2D rb;

    float x;
    float y;

    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + new Vector3(x, y, 0f) * Speed * Time.fixedDeltaTime);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    // {

    // }
}
