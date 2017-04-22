using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour {

	public Transform orbita;
	public Transform basePos;
	public Transform player;

	public Player2Movement pm;

	private Vector3 zAxis = new Vector3(0, 0, 1);
	Vector3 esq, dir;

	bool lancado = false;

	float rotZ;
	float speed;

	void Start ()
	{
        player = GameObject.FindGameObjectWithTag("Player").transform;
        orbita = GameObject.FindGameObjectWithTag("Orbit").transform;
        basePos = GameObject.FindGameObjectWithTag("Hand").transform;
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2Movement>();
		esq = new Vector3 (-0.13f, -0.13f, 0.13f);
		dir = new Vector3 (0.13f, 0.13f, 0.13f);
	}
	
	void Update () 
	{
		switch (lancado) {
		case true:
			noMundo ();
			break;
		case false:
			naMao ();
			break;
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			lancado = true;
		}
	}

	void naMao()
	{
		transform.position = basePos.position;
		transform.localEulerAngles = new Vector3(player.localEulerAngles.x, player.localEulerAngles.y, (player.localEulerAngles.z - 66f));

		rotZ = transform.localEulerAngles.z;

		if (Input.GetAxis ("Horizontal") > 0f)
			transform.localScale = dir;
		else if (Input.GetAxis ("Horizontal") < 0f)
			transform.localScale = esq;

		if (pm.facingRight)
			speed = 2f;
		else if (!pm.facingRight)
			speed = -2f;
	}

	void noMundo()
	{
		transform.RotateAround (orbita.position, zAxis, speed);
		rotZ -= 720f * Time.deltaTime;

		transform.localEulerAngles = new Vector3 (0f, 0f, rotZ);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player") 
		{
			if (speed == -2f) {
				if (pm.facingRight) {
					lancado = false;
				}
			}
			if (speed == 2f) {
				if (!pm.facingRight) {
					lancado = false;
				}
			}
		}
	}
}
