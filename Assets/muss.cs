using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muss : MonoBehaviour {

	void Start () {
        FindObjectOfType<AudioManager>().Play("theme");
    }

}
