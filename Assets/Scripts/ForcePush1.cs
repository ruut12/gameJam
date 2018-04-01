using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePush1 : MonoBehaviour {

	public float radius;
	public float power;
	public float PushCooldown = 1.0f;

	long lasActionTime;
	public bool isAction = false;

	void Start()
	{
		
	}

	void FixedUpdate ()
	{
		var nowTicks = System.DateTime.Now.Ticks;
		if (Input.GetButtonDown("Fire1")) {
			//			var player = gameObject.GetComponent<Player>();

			if ((lasActionTime + (PushCooldown * 10000000)) < (nowTicks)){
				isAction = true;
				lasActionTime = nowTicks; // alusta tegemist
			}
			Debug.Log (nowTicks - lasActionTime);
			if (isAction && (lasActionTime + (PushCooldown * 10000000)) < (nowTicks)){
				isAction = false; // tee actionit mingi 1 sekund
			}

			if (isAction) {
				pushItems ();
			}

			isAction = false;

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