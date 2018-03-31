using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb2d, rb2d2, rb2d3, rb2d4;

    // Use this for initialization
    void Start () {
        rb2d = GameObject.Find("PlayerOne").GetComponent<Rigidbody2D>();
        rb2d2 = GameObject.Find("PlayerTwo").GetComponent<Rigidbody2D>();
        rb2d3 = GameObject.Find("PlayerTwo").GetComponent<Rigidbody2D>();
        rb2d4 = GameObject.Find("PlayerTwo").GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float moveHorizontal1 = Input.GetAxis("xbox1hor");
        float moveHorizontal2 = Input.GetAxis("xbox2hor");
        float moveHorizontal3 = Input.GetAxis("xbox3hor");
        float moveHorizontal4 = Input.GetAxis("xbox4hor");

        //Store the current vertical input in the float moveVertical.

        if (Input.GetKeyDown("joystick 1 button 0"))
        {
            rb2d.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown("joystick 2 button 0"))
        {
            rb2d2.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown("joystick 3 button 0"))
        {
            rb2d2.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown("joystick 4 button 0"))
        {
            rb2d2.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }


        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement1 = new Vector2(moveHorizontal1, 0);
        Vector2 movement2 = new Vector2(moveHorizontal2, 0);
        Vector2 movement3 = new Vector2(moveHorizontal3, 0);
        Vector2 movement4 = new Vector2(moveHorizontal4, 0);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement1 * speed);
        rb2d2.AddForce(movement2 * speed);
        rb2d3.AddForce(movement3 * speed);
        rb2d4.AddForce(movement4 * speed);

    }
}
