﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartAnykey : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			print ("any key pressed");
			Application.LoadLevel("PlayerSelect");
		}
	}
}
