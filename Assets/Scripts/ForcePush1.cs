using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePush1 : MonoBehaviour {

	public float radius;
	public float power;

	void Start()
	{
		
	}

	void FixedUpdate ()
	{
		if (Input.GetButtonDown("Fire1")) {

            FindObjectOfType<AudioManager>().Play("push");

            Vector3 explosionPos = transform.position;
			Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);

			foreach (Collider2D hit in colliders) {
				if (hit && hit.GetComponent<Rigidbody2D>())
					hit.GetComponent<Rigidbody2D>().AddExplosionForce(power, explosionPos, radius, 3.0F);

			}	
		}	

	}
}