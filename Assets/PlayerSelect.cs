using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour {

	void Start () {
        FindObjectOfType<AudioManager>().Play("fury");
        FindObjectOfType<AudioManager>().Play("intro");
    }

}
