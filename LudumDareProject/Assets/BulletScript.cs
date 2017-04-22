using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody2D rb;
    public bool playerFacingRight;
    float gravityForce = 1000;
    float speed = 12f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (playerFacingRight)
            speed *= -1;
    }
	void FixedUpdate ()
    {
        rb.velocity = transform.right * speed;
        rb.AddForce(-transform.up * gravityForce, ForceMode2D.Force);
    }
}
