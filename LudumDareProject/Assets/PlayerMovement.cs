using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;
    Rigidbody2D rb;
    Vector3 esq, dir;
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
        dirX = Input.GetAxis("Horizontal");

        rb.velocity = transform.right * dirX * speed;
        rb.AddForce(-transform.up * gravityForce, ForceMode2D.Force);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBullet(facingRight);
        }

        if (dirX > 0f && facingRight)
            Flip();
        else if (dirX < 0f && !facingRight)
            Flip();
    }

    void SpawnBullet(bool playerLookingDirection)
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        facingRight = !facingRight;
    }
}
