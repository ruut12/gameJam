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
        rb2d3 = GameObject.Find("PlayerThree").GetComponent<Rigidbody2D>();
        rb2d4 = GameObject.Find("PlayerFour").GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate() {

        Debug.Log(rb2d2);

        float moveHorizontal1 = Input.GetAxis("xbox1hor");
        float moveHorizontal2 = Input.GetAxis("xbox2hor");
        float moveHorizontal3 = Input.GetAxis("xbox3hor");
        float moveHorizontal4 = Input.GetAxis("xbox4hor");

        //Store the current vertical input in the float moveVertical.

        if (rb2d != null){ 
            if (Input.GetKeyDown("joystick 1 button 0"))
            {
                rb2d.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            }
            Vector2 movement1 = new Vector2(moveHorizontal1, 0);
            rb2d.AddForce(movement1 * speed);
        }
        if (rb2d2 != null)
        {
            if (Input.GetKeyDown("joystick 2 button 0"))
            {
                rb2d2.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            }
            Vector2 movement2 = new Vector2(moveHorizontal2, 0);
            rb2d2.AddForce(movement2 * speed);
        }
        if (rb2d3 != null)
        {
            if (Input.GetKeyDown("joystick 3 button 0"))
            {
                rb2d3.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            }
            Vector2 movement3 = new Vector2(moveHorizontal3, 0);
            rb2d3.AddForce(movement3 * speed);
        }
        if (rb2d4 != null)
        {
            if (Input.GetKeyDown("joystick 4 button 0"))
            {
                rb2d4.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            }
            Vector2 movement4 = new Vector2(moveHorizontal4, 0);
            rb2d3.AddForce(movement4 * speed);
        }

    }
}
