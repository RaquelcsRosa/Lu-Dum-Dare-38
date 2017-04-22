using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    Transform orbita;

    [HideInInspector]
    public bool facingRight;

    Rigidbody2D rb;
    private Vector3 zAxis = new Vector3(0, 0, 1);
    Vector3 jumpPosition;

    float dirX;
    float speed = 2;
    float rotZ;
    bool jumping = false;
    bool jumped = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            dirX = 1;
            transform.RotateAround(orbita.position, zAxis, speed * dirX);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            dirX = -1;
            transform.RotateAround(orbita.position, zAxis, speed * dirX);
        }
        else
        {
            dirX = 0;
        }

        if (Input.GetKey(KeyCode.W) && !jumping)
        {
            jumping = true;
            StartCoroutine(JumpUp());
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBullet(facingRight);
        }

        if (dirX > 0f && !facingRight)
            Flip();
        else if (dirX < 0f && facingRight)
            Flip();
    }

    void SpawnBullet(bool playerLookingDirection)
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
    }

    IEnumerator JumpUp()
    {
        jumpPosition = this.transform.position;
        for (int i = 0; i <= 10; i++)
        {
            this.transform.position += transform.up * i/90 * 2;
            yield return new WaitForSeconds(0.01f);
        }
        while (this.transform.position != jumpPosition)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, jumpPosition, 1);
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
