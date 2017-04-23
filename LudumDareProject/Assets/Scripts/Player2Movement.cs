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
    Vector3 jumpPosition;

    float dirX;
    float speed = 2;
    bool jumping;
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

        if (Input.GetKey(KeyCode.UpArrow) && !jumping)
        {
            jumping = true;
            StartCoroutine(JumpUp());
        }
        if (dirX > 0f && !facingRight)
            Flip();
        else if (dirX < 0f && facingRight)
            Flip();
    }
    
    IEnumerator JumpUp()
    {
        jumpPosition = this.transform.position;
        for (int i = 0; i <= 10; i++)
        {
            this.transform.position += transform.up * i / 90 * 2;
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i <= 10; i++)
        {
            this.transform.position -= transform.up * i / 90 * 2;
            yield return new WaitForSeconds(0.01f);
        }
        jumping = false;
    }
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        facingRight = !facingRight;
    }
}
