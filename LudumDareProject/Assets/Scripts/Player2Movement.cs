using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    Rigidbody2D rb;
    float dirX;
    float gravityForce = 1000;
    float speed = 10;
    [HideInInspector]
    public bool facingRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dirX = 1;
            rb.velocity = transform.right * dirX * speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            dirX = -1;
            rb.velocity = transform.right * dirX * speed;
        }
        else
        {
            dirX = 0;
        }
        rb.AddForce(-transform.up * gravityForce, ForceMode2D.Force);

        if (dirX > 0f && facingRight)
            Flip();
        else if (dirX < 0f && !facingRight)
            Flip();
    }
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        facingRight = !facingRight;
    }
}
