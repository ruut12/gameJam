using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneController : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GameObject.Find("PlayerOne").GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Store the current vertical input in the float moveVertical.

        if (rb2d != null)
        {
            float moveHorizontal1 = Input.GetAxis("xbox1hor");
            if (Input.GetKeyDown("joystick 1 button 0"))
            {
                rb2d.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            }
            Vector2 movement1 = new Vector2(moveHorizontal1, 0);
            rb2d.AddForce(movement1 * speed);
        }
    }
}
