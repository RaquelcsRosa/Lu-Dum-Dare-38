using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    [SerializeField]
    float jumpSpeed;
    [SerializeField]
    Transform orbita;

    [HideInInspector]
    public bool facingRight;

    Rigidbody2D rb;
    private Vector3 zAxis = new Vector3(0, 0, 1);

    float dirX;
    float speed = 2;
    bool colliding;
    float rotZ;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dirX = 1;
            transform.RotateAround(orbita.position, zAxis, speed * dirX);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            dirX = -1;
            transform.RotateAround(orbita.position, zAxis, speed * dirX);
        }
        else
        {
            dirX = 0;
        }
        if (dirX > 0f && facingRight)
            Flip();
        else if (dirX < 0f && !facingRight)
            Flip();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Orbit"))
        {
            colliding = true;
        }
    }
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        facingRight = !facingRight;
    }
}
