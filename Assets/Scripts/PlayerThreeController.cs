using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThreeController : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb2d3;

    // Use this for initialization
    void Start()
    {
        rb2d3 = GameObject.Find("PlayerThree").GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Store the current vertical input in the float moveVertical.
        if (rb2d3 != null)
        {
            float moveHorizontal3 = Input.GetAxis("xbox3hor");
            if (Input.GetKeyDown("joystick 3 button 0"))
            {
                rb2d3.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            }
            Vector2 movement3 = new Vector2(moveHorizontal3, 0);
            rb2d3.AddForce(movement3 * speed);
        }
    }
}
