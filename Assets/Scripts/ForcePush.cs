using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePush : MonoBehaviour {

	public float radius;
	public float power;

	void Start()
	{
		
	}

	void FixedUpdate ()
	{
		if (Input.GetKeyDown("x")){
			

			Vector3 explosionPos = transform.position;
			Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);


			//Debug.Log ("käib", gameObject);
			//var hitColliders = Physics2D.OverlapArea(transform.x, transform.y, 1 << LayerMask.NameToLayer("Push items")); //layermask to filter the varius useless colliders
			//Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);
			foreach (Collider2D hit in colliders) {
				if (hit && hit.GetComponent<Rigidbody2D>())
					hit.GetComponent<Rigidbody2D>().AddExplosionForce(power, explosionPos, radius, 3.0F);

			}	
		}	

	}
}