using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float gravityForce;
    [SerializeField]
    float speed;
    float dirX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        dirX = Input.GetAxis("Horizontal");

        rb.velocity = transform.right * dirX * speed * Time.deltaTime;

        rb.AddForce(-transform.up * gravityForce, ForceMode2D.Force);
    }
}
