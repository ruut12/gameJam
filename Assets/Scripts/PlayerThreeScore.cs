using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerThreeScore : MonoBehaviour
{

    public int lives = 3;
    public Text LivesText;
    // Use this for initialization
    void Start()
    {
        LivesText = GameObject.Find("PlayerThreeScore").GetComponent<Text>();

        LivesText.text = "Lives left: " + lives;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DangerCollider")
        {
            Debug.Log("Collision detected");
            lives -= 1;
        }
        if (lives < 1)
        {
            Debug.Log("game over");
        }
    }

    // Update is called once per frame
    void Update()
    {
        LivesText.text = "Lives left: " + lives;
    }
}
