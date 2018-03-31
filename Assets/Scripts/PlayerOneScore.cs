using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOneScore : MonoBehaviour {

    public int lives = 3;
    public Text LivesText;
	// Use this for initialization
	void Start () {
		LivesText = GameObject.Find("PlayerOneScore").GetComponent<Text>();

        LivesText.text = "" + lives;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DangerCollider")
        {
            Debug.Log("Collision detected");
            //FindObjectOfType<AudioManager>().Play("damage");
            lives -= 1;
        }
        if (lives < 1)
        {
            Debug.Log("game over");
            //FindObjectOfType<AudioManager>().Play("death");
        }
    }

    // Update is called once per frame
    void Update () {
        LivesText.text = "" + lives;
	}
}
