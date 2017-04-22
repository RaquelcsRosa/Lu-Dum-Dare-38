using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform orbita;
    private Vector3 zAxis = new Vector3(0, 0, 1);
    public bool playerFacingRight;
    float speed = 4f;
    float rotZ;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        orbita = GameObject.FindGameObjectWithTag("Orbit").transform;
        if (!playerFacingRight)
            speed *= -1;
    }
	void FixedUpdate ()
    {

        transform.RotateAround(orbita.position, zAxis, speed);
        rotZ -= 720f * Time.deltaTime;

        transform.localEulerAngles = new Vector3(0f, 0f, rotZ);
    }
}
