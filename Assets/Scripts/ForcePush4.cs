using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePush4 : MonoBehaviour {

	public float radius;
	public float power;
	public float PushCooldown = 3.0f;

	long lasActionTime;
	public bool canPush = true;

	void Start()
	{

	}

	void FixedUpdate ()
	{
		var nowTicks = System.DateTime.Now.Ticks;

		if ((lasActionTime + (PushCooldown * 10000000)) < (nowTicks)) {
			canPush = true;
			lasActionTime = nowTicks; // alusta tegemist
		}


		if (Input.GetButtonDown("Fire4")) {
			if (canPush) {
				pushItems ();
				canPush = false;
			}
		}
	}
	void pushItems(){
		FindObjectOfType<AudioManager>().Play("push");

		Vector3 explosionPos = transform.position;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);

		foreach (Collider2D hit in colliders) {
			if (hit && hit.GetComponent<Rigidbody2D>())
				hit.GetComponent<Rigidbody2D>().AddExplosionForce(power, explosionPos, radius, 3.0F);

		}	
	}
}