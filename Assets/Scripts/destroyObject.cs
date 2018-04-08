using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObject : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {
		Destroy (gameObject, 3.0F);	
	}
}
