using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;

    private Rigidbody2D rb;

    float x;
    float y;

    float bottomLimit;
    float topLimit;
    float leftLimit;
    float rightLimit;  
    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
        bottomLimit = bottomLeft.y;
        leftLimit = bottomLeft.x;

        Vector3 topRight = Camera.main.ViewportToWorldPoint(Vector3.one);
        topLimit = topRight.y;
        rightLimit = topRight.x;

    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(transform.position + new Vector3(x, y, 0f) * Speed * Time.fixedDeltaTime);

        Vector3 desiredPosition = transform.position + new Vector3(x, y, 0f) * Speed * Time.fixedDeltaTime;

        desiredPosition.x = Mathf.Clamp(desiredPosition.x, leftLimit, rightLimit);

        desiredPosition.y = Mathf.Clamp(desiredPosition.y, bottomLimit, topLimit);

        //Calculate Movement
        rb.MovePosition(desiredPosition);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    // {

    // }
}
